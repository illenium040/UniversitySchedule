using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.RepositoryInterfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm.UpdateDbData
{
    public class UpdatedGroups : IUpdateData<Specialty, Group>
    {
        private DataGridView _mainGrid;
        private DataGridView _extraGrid;
        public UpdatedData<Group> UpdatedData { get; }
        public UpdatedGroups(DataGridView updatedMainDataGrid, DataGridView updatedExtraInfoDataGrid)
        {
            UpdatedData = new UpdatedData<Group>();
            _mainGrid = updatedMainDataGrid;
            _extraGrid = updatedExtraInfoDataGrid;
        }

        public void Add()
        {
            var group = new Group();
            UpdatedData.Added.Add(group);
            foreach (DataGridViewRow row in _mainGrid.Rows)
            {
                if (!UpdatedData.DataRowToData.ContainsKey(row))
                {
                    UpdatedData.DataRowToData.Add(row, group);
                    return;
                }
            }
        }

        public void Remove(DataGridViewRow row)
        {
            UpdatedData.Removed.Add(UpdatedData.DataRowToData[row]);
            UpdatedData.DataRowToData.Remove(row);
        }

        public bool Save(IRepository<Specialty> repo)
        {
            var specRepo = repo as ISpecialtyRepository;
            
            UpdatedData.Check();
            try
            {
                foreach (var item in UpdatedData.Added)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
                    if (!IsValid(k.Index))
                    {
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Группы\r\nНеобходимо заполнить все необходимые поля");
                        return false;
                    }
                    specRepo.AddGroup(item);
                }
                foreach (var item in UpdatedData.Removed)
                    repo.Get(item.SpecialtyId).Groups.Remove(item);
                foreach (var item in UpdatedData.Updated)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
                    if (!IsValid(k.Index))
                    {
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Группы\r\nНеобходимо заполнить все необходимые поля");
                        return false;
                    }
                    var spec = repo.Get(item.SpecialtyId);
                    var index = spec.Groups.IndexOf(item);
                    spec.Groups[index] = item;
                }
                return true;
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("Необходимо создать план с таким id", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool IsValid(int index)
        {
            if (_mainGrid[0, index].Value is null &&
                _mainGrid[3, index].Value is null)
                return false;
            return true;
        }

        public void SetGrid(IRepository<Specialty> repo)
        {
            _mainGrid.Clear();
            _extraGrid.Clear();
            _extraGrid.Invoke(g =>
            {
                g.Columns.Add("ID", "ID");
                g.Columns.Add("Index", "Индекс");
                g.Columns.Add("Name", "Наименование");
                g.Columns.Add("Code", "Код");
                g.Columns.Add("Группы", "Группы");
            });
            _mainGrid.Invoke(g =>
            {
                g.Columns.Add("ID", "ID");
                g.Columns.Add("Shift", "Текущая смена");
                g.Columns.Add("Year", "Год поступления");
                g.Columns.Add("SpecId", "ID специальности");
            });
            var groups = new Dictionary<int, Group>();
            foreach (var spec in repo.GetAll())
            {
                foreach (var group in spec.Groups)
                {
                    if (!groups.ContainsKey(group.Id))
                    {
                        groups.Add(group.Id, group);
                        _mainGrid.Invoke(g =>
                        {
                            var index = g.Rows.Add(group.Id, group.CurrentShift, group.ReceiptYear, group.SpecialtyId);
                            UpdatedData.DataRowToData.Add(g.Rows[index], group);
                        });
                    }
                }
                _extraGrid.Invoke(g =>
                {
                    var strb = new StringBuilder();
                    for (int i = 0; i < spec.Groups.Count; i++)
                        strb.Append($"{spec.Groups[i].Id};");
                    g.Rows.Add(spec.Id, spec.Index, spec.Name, spec.Code,
                        strb.ToString());
                    
                });
            }
        }

        public void Update(int rowIndex)
        {
            if (!IsValid(rowIndex)) return;
            if (int.TryParse(_mainGrid[0, rowIndex].Value?.ToString(), out int gId) &&
                int.TryParse(_mainGrid[3, rowIndex].Value?.ToString(), out int sId))
            {
                var g = UpdatedData.DataRowToData[_mainGrid.Rows[rowIndex]];
                g.Id = gId;
                if(int.TryParse(_mainGrid[2, rowIndex].Value?.ToString(), out int year))
                    g.ReceiptYear = year;
                if(int.TryParse(_mainGrid[1, rowIndex].Value?.ToString(), out int shift))
                    g.CurrentShift = shift;
                g.SpecialtyId = sId;
                UpdatedData.Updated.Add(g);
            }
            
        }
    }
}
