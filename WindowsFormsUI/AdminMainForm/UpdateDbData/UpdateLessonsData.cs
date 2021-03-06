using DataAccess.Entities;
using DataAccess.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm.UpdateDbData
{
    public class UpdateLessonsData : IUpdateData<TeacherSubject>
    {
        public UpdatedData<TeacherSubject> UpdatedData { get; }

        private DataGridView _grid;
        public UpdateLessonsData(DataGridView grid)
        {
            UpdatedData = new UpdatedData<TeacherSubject>();
            _grid = grid;
        }

        public void Add()
        {
            var ts = new TeacherSubject
            {
                Subject = new Subject(),
                Teacher = new Teacher()
            };
            UpdatedData.Added.Add(ts);
            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (!UpdatedData.DataRowToData.ContainsKey(row))
                {
                    UpdatedData.DataRowToData.Add(row, ts);
                    return;
                }
            }
        }

        public void Remove(DataGridViewRow row)
        {
            UpdatedData.Removed.Add(UpdatedData.DataRowToData[row]);
            UpdatedData.DataRowToData.Remove(row);
        }

        public void Update(int rowIndex)
        {
            if (UpdateLesson(UpdatedData.DataRowToData[_grid.Rows[rowIndex]], rowIndex) &&
                !UpdatedData.Updated.Contains(UpdatedData.DataRowToData[_grid.Rows[rowIndex]]))
                UpdatedData.Updated.Add(UpdatedData.DataRowToData[_grid.Rows[rowIndex]]);
        }

        public void SetGrid(IRepository<TeacherSubject> repo)
        {
            _grid.Clear();
            _grid.Invoke(() =>
            {
                _grid.Columns.Add("IDT", "ID");
                _grid.Columns.Add("Фамилия", "Фамилия");
                _grid.Columns.Add("Инициалы", "Инициалы");
                _grid.Columns.Add("Полное имя", "Полное имя");
                _grid.Columns.Add("IDS", "ID");
                _grid.Columns.Add("Полное наименование предмета", "Полное наименование предмета");
                _grid.Columns.Add("Краткое наименование предмета", "Краткое наименование предмета");
            });

            foreach (var ts in repo.GetAll())
            {
                _grid.Invoke(g =>
                {
                    var i = g.Rows.Add(ts.TeacherId, ts.Teacher.Lastname, ts.Teacher.ShortFirstname, ts.Teacher.FullFirstname,
                        ts.SubjectId, ts.Subject.FullName, ts.Subject.ShortName);
                    UpdatedData.DataRowToData.Add(g.Rows[i], ts);
                });
            }
        }

        public bool Save(IRepository<TeacherSubject> repo)
        {
            try
            {
                UpdatedData.Check();
                foreach (var item in UpdatedData.Added)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
                    if (!IsValid(k.Index))
                    {
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Преподаватель предмет\r\nНеобходимо заполнить все необходимые поля");
                        return false;
                    }
                    repo.Add(item);
                }
                foreach (var item in UpdatedData.Removed)
                    repo.Remove(item);
                foreach (var item in UpdatedData.Updated)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
                    if (!IsValid(k.Index))
                    {
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Преподаватель предмет\r\nНеобходимо заполнить все необходимые поля");
                        return false;
                    }
                    repo.Update(item);
                }
                return true;
            }
            catch (Exception exc)
            {
                if (exc.InnerException != null)
                    WinFormStaticHelper.ShowErrorMsgBox(exc.InnerException.Message);
                else WinFormStaticHelper.ShowErrorMsgBox(exc.Message);
                return false;
            }
        }

        private bool UpdateLesson(TeacherSubject ts, int rowIndex)
        {
            if (!IsValid(rowIndex)) return false;
            if (int.TryParse(_grid[0, rowIndex].Value?.ToString(), out int tval))
            {
                ts.TeacherId = tval;
                ts.Teacher.Id = tval;
            }
            if (int.TryParse(_grid[4, rowIndex].Value?.ToString(), out int sval))
            {
                ts.SubjectId = sval;
                ts.Subject.Id = sval;
            }
            ts.Teacher.Lastname = _grid[1, rowIndex].Value?.ToString();
            ts.Teacher.ShortFirstname = _grid[2, rowIndex].Value?.ToString();
            ts.Teacher.FullFirstname = _grid[3, rowIndex].Value?.ToString();
            ts.Subject.FullName = _grid[5, rowIndex].Value?.ToString();
            ts.Subject.ShortName = _grid[6, rowIndex].Value?.ToString();
            return true;
        }

        private bool IsValid(int rowIndex)
        {
            if (_grid[0, rowIndex].Value is null ||
                _grid[4, rowIndex].Value is null)
                return false;
            return true;
        }
    }
}
