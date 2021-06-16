using DataAccess.Entities;
using DataAccess.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm.UpdateDbData
{
    public class UpdatedSpecialty : IUpdateData<Specialty>
    {
        public UpdatedData<Specialty> UpdatedData { get; }

        private DataGridView _mainGrid;
        private DataGridView _extraGrid;
        public UpdatedSpecialty(DataGridView mainGrid, DataGridView extraGrid)
        {
            UpdatedData = new UpdatedData<Specialty>();
            _mainGrid = mainGrid;
            _extraGrid = extraGrid;
        }

        public void Add()
        {
            var specialty = new Specialty()
            {
                Groups = new List<Group>()
            };
            UpdatedData.Added.Add(specialty);
            foreach (DataGridViewRow row in _mainGrid.Rows)
            {
                if (!UpdatedData.DataRowToData.ContainsKey(row))
                {
                    UpdatedData.DataRowToData.Add(row, specialty);
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
            try
            {
                UpdatedData.Check();
                foreach (var item in UpdatedData.Added)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
                    if (!IsValid(k.Index))
                    {
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Специальность\r\nНеобходимо заполнить все необходимые поля");
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
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Специальность\r\nНеобходимо заполнить все необходимые поля");
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

        private bool IsValid(int index)
        {
            if (_mainGrid[0, index].Value is null)
                return false;
            return true;
        }

        public void SetGrid(IRepository<Specialty> repo)
        {
            _mainGrid.Clear();
            _extraGrid.Clear();
            _mainGrid.Invoke(g =>
            {
                g.Columns.Add("ID", "ID");
                g.Columns.Add("Index", "Индекс");
                g.Columns.Add("Name", "Наименование");
                g.Columns.Add("Code", "Код");
                g.Columns.Add("Группы", "Группы");
            });
            _extraGrid.Invoke(g =>
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
                        _extraGrid.Invoke(g =>
                        {
                            g.Rows.Add(group.Id, group.CurrentShift, group.ReceiptYear, spec.Id);
                        });
                    }
                }
                _mainGrid.Invoke(g =>
                {
                    var strb = new StringBuilder();
                    for (int i = 0; i < spec.Groups.Count; i++)
                        strb.Append($"{spec.Groups[i].Id};");
                    var index = g.Rows.Add(spec.Id, spec.Index, spec.Name, spec.Code, 
                        strb.ToString());
                    UpdatedData.DataRowToData.Add(g.Rows[index], spec);
                });
            }
        }

        public void Update(int rowIndex)
        {
            if (!IsValid(rowIndex)) return;
            if (int.TryParse(_mainGrid[0, rowIndex].Value?.ToString(), out int id))
            {
                var spec = UpdatedData.DataRowToData[_mainGrid.Rows[rowIndex]];
                spec.Id = id;
                spec.Index = _mainGrid[1, rowIndex].Value?.ToString();
                spec.Name = _mainGrid[2, rowIndex].Value?.ToString();
                spec.Code = _mainGrid[3, rowIndex].Value?.ToString();
                if(!UpdatedData.Updated.Contains(spec))
                    UpdatedData.Updated.Add(spec);
            }
            
        }
    }
}
