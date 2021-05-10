using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.AdminMainForm
{
    partial class AdminForm : Form, IAdminFormUpdateDB
    {
        private class UpdatedData<T>
        {
            public Dictionary<DataGridViewRow, T> DataRowToData { get; }
            public List<T> Added { get; }
            public List<T> Removed { get; }
            public List<T> Updated { get; }

            public UpdatedData()
            {
                DataRowToData = new Dictionary<DataGridViewRow, T>();
                Added = new List<T>();
                Removed = new List<T>();
                Updated = new List<T>();
            }

            public void Check()
            {
                for (int i = 0; i < Added.Count; i++)
                {
                    if (Removed.Contains(Added[i]))
                    {
                        Added.Remove(Added[i]);
                        i--;
                    }
                }
                for (int i = 0; i < Updated.Count; i++)
                {
                    if(Removed.Contains(Updated[i]) || Added.Contains(Updated[i]))
                    {
                        Updated.Remove(Updated[i]);
                        i--;
                    }
                }
            }
        } 
        public bool IsConfirmationRequired => isConfirmation.Checked;
        private int _selectedIndex;
        private string _selectedItem;

        private UpdatedData<TeacherSubject> _lessonsData;

        private Dictionary<DataGridViewRow, PlanInformation> _dataRowToPlanInfo;
        private Dictionary<DataGridViewRow, Specialty> _dataRowToSpecialty;

        public IEnumerable<string> TableNameList
        {
            get
            {
                foreach (var item in tableNameList.Items)
                    yield return item as string;
            }
            set
            {
                if (value.Count() <= 0) return;
                tableNameList.Invoke(() =>
                {
                    tableNameList.Items.AddRange(value.ToArray());
                    if (tableNameList.SelectedIndex < 0 && tableNameList.Items.Count > 0)
                        tableNameList.SelectedIndex = 0;
                });
            }
        }

        public string SelectedTable 
        {
            get
            {
                tableNameList.Invoke(() => _selectedItem = tableNameList.SelectedItem as string);
                return _selectedItem;
            }
        }

        public int SelectedIndex
        {
            get
            {
                tableNameList.Invoke(() => _selectedIndex = tableNameList.SelectedIndex);
                return _selectedIndex;
            }
        }
        public bool IsPreLoading 
        {
            get => loadingPanel.Visible;
            set => loadingPanel.Invoke(()=> loadingPanel.Visible = value); 
        }

        public event Action SaveChanges;
        public event Action LoadData;
        public event Action TableChanged;
        public event Action<TeacherSubject> LessonRemoved;
        public event Action<TeacherSubject> LessonUpdated;
        public event Action<TeacherSubject> LessonAdded;

        public void SetLessons(ILessonsRepository lessonContext)
        {
            ClearDataGrid();
            updateDataGrid.Invoke(() =>
            {
                updateDataGrid.Columns.Add("IDT", "ID");
                updateDataGrid.Columns.Add("Фамилия", "Фамилия");
                updateDataGrid.Columns.Add("Инициалы", "Инициалы");
                updateDataGrid.Columns.Add("Полное имя", "Полное имя");
                updateDataGrid.Columns.Add("IDS", "ID");
                updateDataGrid.Columns.Add("Полное наименование предмета", "Полное наименование предмета");
                updateDataGrid.Columns.Add("Краткое наименование предмета", "Краткое наименование предмета");
            });
            
            foreach (var ts in lessonContext.GetAll())
            {
                updateDataGrid.Invoke(g =>
                {
                    var i = g.Rows.Add(ts.TeacherId, ts.Teacher.Lastname, ts.Teacher.ShortFirstname, ts.Teacher.FullFirstname,
                        ts.SubjectId, ts.Subject.FullName, ts.Subject.ShortName);
                    _lessonsData.DataRowToData.Add(g.Rows[i], ts);
                });
            }
        }

        public void SetPlan(IPlanInformationRepository planContext)
        {
            ClearDataGrid();
            planContext.GetAll();
        }

        public void SetSpecialty(ISpecialtyRepository specialtyContext)
        {
            ClearDataGrid();
            specialtyContext.GetAll();
        }

        public void SetUpdateEvents()
        {
            _lessonsData = new UpdatedData<TeacherSubject>();

            _dataRowToPlanInfo = new Dictionary<DataGridViewRow, PlanInformation>();
            _dataRowToSpecialty = new Dictionary<DataGridViewRow, Specialty>();
            updateDataGrid.SetDoubleBuffered();

            btnSaveChanges.Click += async (o, e) =>
            {
                _lessonsData.Check();
                foreach (var item in _lessonsData.Added)
                    LessonAdded(item);
                foreach (var item in _lessonsData.Removed)
                    LessonRemoved(item);
                foreach (var item in _lessonsData.Updated)
                    LessonUpdated(item);
                await _actionProxy?.InvokeAsync(SaveChanges);
            };
            tableNameList.SelectedIndexChanged += async (o, e) => await _actionProxy?.InvokeAsync(TableChanged);
            Shown += async (o, e) => await _actionProxy?.InvokeAsync(LoadData);

            updateDataGrid.KeyDown += UpdateDataGrid_KeyDown;
            updateDataGrid.UserDeletedRow += UpdateDataGrid_UserDeletedRow;
            updateDataGrid.CellValueChanged += UpdateDataGrid_CellValueChanged;
            updateDataGrid.UserAddedRow += UpdateDataGrid_UserAddedRow;
        }

        private void UpdateDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            var teacher = new Teacher();
            var subject = new Subject();
            teacher.TeacherSubject = new List<TeacherSubject>() {
                new TeacherSubject
                {
                    Subject = subject,
                    Teacher = teacher
                }
            };
            subject.TeacherSubject = new List<TeacherSubject>() { teacher.TeacherSubject[0] };
            _lessonsData.Added.Add(teacher.TeacherSubject[0]);
            foreach (DataGridViewRow row in updateDataGrid.Rows)
            {
                if(!_lessonsData.DataRowToData.ContainsKey(row))
                    _lessonsData.DataRowToData.Add(row, teacher.TeacherSubject[0]);
            }
           
        }

        private void UpdateDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (UpdateLesson(_lessonsData.DataRowToData[updateDataGrid.Rows[e.RowIndex]], e.RowIndex) &&
                !_lessonsData.Updated.Contains(_lessonsData.DataRowToData[updateDataGrid.Rows[e.RowIndex]]))
                _lessonsData.Updated.Add(_lessonsData.DataRowToData[updateDataGrid.Rows[e.RowIndex]]);
        }

        private void UpdateDataGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _lessonsData.Removed.Add(_lessonsData.DataRowToData[e.Row]);
        }

        private void UpdateDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
            {
                updateDataGrid.CancelEdit();
                updateDataGrid.RefreshEdit();
            }
        }

        private void ClearDataGrid()
        {
            updateDataGrid.Columns.Clear();
            updateDataGrid.Rows.Clear();
            updateDataGrid.Invoke(g => g.Refresh());
        }

        private bool UpdateLesson(TeacherSubject ts, int rowIndex)
        {
            for (int i = 0; i < 6; i++)
            {
                if (updateDataGrid[i, rowIndex].Value is null)
                    return false;
                
            }
            if (int.TryParse(updateDataGrid[0, rowIndex].Value?.ToString(), out int tval))
            {
                ts.TeacherId = tval;
                ts.Teacher.Id = tval;
            }
            if (int.TryParse(updateDataGrid[4, rowIndex].Value?.ToString(), out int sval))
            {
                ts.SubjectId = sval;
                ts.Subject.Id = sval;
            }
            ts.Teacher.Lastname = (string)updateDataGrid[1, rowIndex].Value;
            ts.Teacher.ShortFirstname = (string)updateDataGrid[2, rowIndex].Value;
            ts.Teacher.FullFirstname = (string)updateDataGrid[3, rowIndex].Value;
            ts.Subject.FullName = (string)updateDataGrid[5, rowIndex].Value;
            ts.Subject.ShortName = (string)updateDataGrid[6, rowIndex].Value;
            return true;
        }

    }
}
