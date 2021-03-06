using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.AdminMainForm.UpdateDbData;
using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.AdminMainForm
{

    partial class AdminForm : Form, IAdminFormUpdateDB
    {
        private ITimetableViewData _formUpdatedData;
        public bool IsConfirmationRequired => isConfirmation.Checked;
        private int _selectedIndex;
        private string _selectedItem;

        private UpdateLessonsData _updatedLessons;
        private UpdatedHourPlanData _updatedHourPlanData;
        private UpdatedPlanInformation _updatedPlanInfo;
        private UpdatedSpecialty _updatedSpecialty;
        private UpdatedGroups _updatedGroups;
        private UpdatedTimetable _updatedTimetableInfo;
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
        public bool IsSavedSuccesfully { get; set; }

        public event Action SaveChanges;
        public event Action LoadData;

        public void SetUpdateEvents()
        {
            _updatedPlanInfo = new UpdatedPlanInformation(updatedMainDataGrid, updatedExtraInfoDataGrid);
            _updatedLessons = new UpdateLessonsData(updatedMainDataGrid);
            _updatedHourPlanData = new UpdatedHourPlanData(updatedMainDataGrid, updatedExtraInfoDataGrid);
            _updatedSpecialty = new UpdatedSpecialty(updatedMainDataGrid, updatedExtraInfoDataGrid);
            _updatedGroups = new UpdatedGroups(updatedMainDataGrid, updatedExtraInfoDataGrid);
            _updatedTimetableInfo = new UpdatedTimetable(updatedMainDataGrid);
            updatedMainDataGrid.SetDoubleBuffered();

            btnSaveChanges.Click += async (o, e) =>
            {
                if (!_updatedLessons.Save(_formUpdatedData.TeacherSubject)) return;
                if (!_updatedHourPlanData.Save(_formUpdatedData.PlansInformation)) return;
                if (!_updatedPlanInfo.Save(_formUpdatedData.PlansInformation)) return;
                if (!_updatedSpecialty.Save(_formUpdatedData.Specialties)) return;
                if (!_updatedGroups.Save(_formUpdatedData.Specialties)) return;
                if (!_updatedTimetableInfo.Save(_formUpdatedData.TimetableView)) return;
                await _actionProxy?.InvokeAsync(SaveChanges);
                if (!IsSavedSuccesfully) return;
                await _actionProxy?.InvokeAsync(TableChanged);
            };
            tableNameList.SelectedIndexChanged += async (o, e) => await _actionProxy?.InvokeAsync(TableChanged);
            Shown += async (o, e) =>
            {
                await _actionProxy?.InvokeAsync(() =>
                {
                    LoadData();
                    TableChanged();
                });
            };

            updatedMainDataGrid.KeyDown += UpdateDataGrid_KeyDown;
            updatedMainDataGrid.UserDeletingRow += UpdatedMainDataGrid_UserDeletingRow;
            updatedMainDataGrid.CellValueChanged += UpdateDataGrid_CellValueChanged;
            updatedMainDataGrid.UserAddedRow += UpdateDataGrid_UserAddedRow;

            btnRefreshDataGrid.Click += BtnRefreshDataGrid_Click;
        }

        private void UpdatedMainDataGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                GetDataModifier().Remove(e.Row);
            }
            catch (Exception exc)
            {
                if (exc.InnerException != null)
                    WinFormStaticHelper.ShowErrorMsgBox(exc.InnerException.Message);
                else WinFormStaticHelper.ShowErrorMsgBox(exc.Message);
            }
        }

        private async void BtnRefreshDataGrid_Click(object sender, EventArgs e)
        {
            await _actionProxy?.InvokeAsync(TableChanged);
        }

        private int _prevIndex = -1;
        private void TableChanged()
        {
            try
            {
                IsPreLoading = true;
                updatedMainDataGrid.Clear();
                updatedExtraInfoDataGrid.Clear();
                SetLabel(SelectedTable);
                switch (SelectedIndex)
                {
                    case 0:
                        {
                            extraGridPanel.Invoke(() => extraGridPanel.Visible = false);
                            if (_prevIndex != 0 && _prevIndex != 5)
                                updatedMainDataGrid.Invoke(g => g.Height += 210);
                            _updatedLessons.UpdatedData.Clear();
                            _updatedLessons.SetGrid(_formUpdatedData.TeacherSubject);
                            break;
                        }
                    case 1:
                        {
                            extraGridPanel.Invoke(() => extraGridPanel.Visible = true);
                            if(_prevIndex == 0 && _prevIndex == 5)
                                updatedMainDataGrid.Invoke(g => g.Height -= 210);
                            _updatedSpecialty.UpdatedData.Clear();
                            _updatedSpecialty.SetGrid(_formUpdatedData.Specialties);
                            break;
                        }
                    case 2:
                        {
                            extraGridPanel.Invoke(() => extraGridPanel.Visible = true);
                            if (_prevIndex == 0 && _prevIndex == 5) 
                                updatedMainDataGrid.Invoke(g => g.Height -= 210);
                            _updatedGroups.UpdatedData.Clear();
                            _updatedGroups.SetGrid(_formUpdatedData.Specialties);
                            break;
                        }
                    case 3:
                        {
                            extraGridPanel.Invoke(() => extraGridPanel.Visible = true);
                            if (_prevIndex == 0 && _prevIndex == 5)
                                updatedMainDataGrid.Invoke(g => g.Height -= 210);
                            _updatedHourPlanData.UpdatedData.Clear();
                            _updatedHourPlanData.SetGrid(_formUpdatedData.PlansInformation);
                            break;
                        }
                    case 4:
                        {
                            extraGridPanel.Invoke(() => extraGridPanel.Visible = true);
                            if (_prevIndex == 0 && _prevIndex == 5)
                                updatedMainDataGrid.Invoke(g => g.Height -= 210);
                            _updatedPlanInfo.UpdatedData.Clear();
                            _updatedPlanInfo.SetExtraRepo(_formUpdatedData.Specialties);
                            _updatedPlanInfo.SetGrid(_formUpdatedData.PlansInformation);
                            break;
                        }
                    case 5:
                        {
                            extraGridPanel.Invoke(() => extraGridPanel.Visible = false);
                            if (_prevIndex != 0 && _prevIndex != 5)
                                updatedMainDataGrid.Invoke(g => g.Height += 210);
                            _updatedTimetableInfo.UpdatedData.Clear();
                            _updatedTimetableInfo.SetGrid(_formUpdatedData.TimetableView);
                            break;
                        }
                    default: break;
                }
                _prevIndex = SelectedIndex;
                OnResize();
                IsPreLoading = false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }


        private void UpdateDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                GetDataModifier().Add();
            }
            catch (Exception exc)
            {
                if (exc.InnerException != null)
                    WinFormStaticHelper.ShowErrorMsgBox(exc.InnerException.Message);
                else WinFormStaticHelper.ShowErrorMsgBox(exc.Message);
            }
        }

        private void UpdateDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GetDataModifier().Update(e.RowIndex);
            }
            catch (Exception exc)
            {
                if (exc.InnerException != null)
                    WinFormStaticHelper.ShowErrorMsgBox(exc.InnerException.Message);
                else WinFormStaticHelper.ShowErrorMsgBox(exc.Message);
            }
        }

        private void UpdateDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
            {
                (sender as DataGridView).CancelEdit();
                (sender as DataGridView).RefreshEdit();
            }
        }

        public void SetData(ITimetableViewData data)
        {
            _formUpdatedData = data;
        }

        private IModifyGridDbData GetDataModifier()
        {
            switch (SelectedIndex)
            {
                case 0: return _updatedLessons;
                case 1: return _updatedSpecialty;
                case 2: return _updatedGroups;
                case 3: return _updatedHourPlanData;
                case 4: return _updatedPlanInfo;
                case 5: return _updatedTimetableInfo;
                default: return null;
            }
        }

        private void SetLabel(string name)
        {
            lblMainTableName.Invoke(() => lblMainTableName.Text = name);
        }
    }
}
