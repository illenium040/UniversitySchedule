using DataAccess.Entities;
using DataAccess.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm.UpdateDbData
{
    public class UpdatedHourPlanData : IUpdateData<PlanInformation, HourPlan>
    {
        public UpdatedData<HourPlan> UpdatedData { get; }
        private DataGridView _mainGrid;
        private DataGridView _subGrid;
        public UpdatedHourPlanData(DataGridView mainGrid, DataGridView subGrid)
        {
            UpdatedData = new UpdatedData<HourPlan>();
            _mainGrid = mainGrid;
            _subGrid = subGrid;
        }

        public void Add()
        {
            var hInfo = new HourPlan();
            UpdatedData.Added.Add(hInfo);
            foreach (DataGridViewRow row in _mainGrid.Rows)
            {
                if (!UpdatedData.DataRowToData.ContainsKey(row))
                {
                    UpdatedData.DataRowToData.Add(row, hInfo);
                    return;
                }
            }
        }

        public void Remove(DataGridViewRow row)
        {
            UpdatedData.Removed.Add(UpdatedData.DataRowToData[row]);
            UpdatedData.DataRowToData.Remove(row);
        }

        public bool Save(IRepository<PlanInformation> repo)
        {
            UpdatedData.Check();
            try
            {
                foreach (var item in UpdatedData.Added)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
                    if (!IsValid(k.Index))
                    {
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Учебный план\r\nНеобходимо заполнить все необходимые поля");
                        return false;
                    }
                    repo.Get(item.Id).HourPlans.Add(item);
                }
                foreach (var item in UpdatedData.Removed)
                    repo.Get(item.Id).HourPlans.Remove(item);
                foreach (var item in UpdatedData.Updated)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
                    if (!IsValid(k.Index))
                    {
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Учебный план\r\nНеобходимо заполнить все необходимые поля");
                        return false;
                    }
                    var plan = repo.Get(item.Id);
                    var index = plan.HourPlans.IndexOf(item);
                    plan.HourPlans[index] = item;
                }
                return true;
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("Необходимо создать план с таким id", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public void SetGrid(IRepository<PlanInformation> repo)
        {
            _mainGrid.Clear();
            _subGrid.Clear();
            _mainGrid.Invoke(g =>
            {
                g.Columns.Add("ID", "ID");
                g.Columns.Add("Sub_ID", "ID предмета");
                g.Columns.Add("Code", "Код");
                for (int i = 0; i < 8; i++)
                    g.Columns.Add($"Semester{i}", $"Семестр {i + 1}");
            });
            _subGrid.Invoke(g =>
            {
                g.Columns.Add("ID", "ID");
                g.Columns.Add("PlanYear", "Год создания плана");
                g.Columns.Add("StudyForm", "Форма обучения");
                g.Columns.Add("SpecialtyID", "ID специальности");
                for (int i = 0; i < 8; i++)
                    g.Columns.Add($"Weeks{i + 1}", $"Недели на семестр {i + 1}");
            });
            foreach (var plan in repo.GetAll())
            {
                _mainGrid.Invoke(g =>
                {
                    for (int i = 0; i < plan.HourPlans.Count; i++)
                    {
                        var index = g.Rows.Add(plan.Id,
                            plan.HourPlans[i].SubjectId,
                            plan.HourPlans[i].Code,
                            plan.HourPlans[i][0],
                            plan.HourPlans[i][1],
                            plan.HourPlans[i][2],
                            plan.HourPlans[i][3],
                            plan.HourPlans[i][4],
                            plan.HourPlans[i][5],
                            plan.HourPlans[i][6],
                            plan.HourPlans[i][7]);
                        UpdatedData.DataRowToData.Add(g.Rows[index], plan.HourPlans[i]);
                    }
                    
                });
                _subGrid.Invoke(g =>
                {
                    var index = g.Rows.Add(plan.Id, plan.PlanYear, plan.StudyForm, plan.SpecialtyId,
                        plan.PlanWeeks?[0],
                        plan.PlanWeeks?[1],
                        plan.PlanWeeks?[2],
                        plan.PlanWeeks?[3],
                        plan.PlanWeeks?[4],
                        plan.PlanWeeks?[5],
                        plan.PlanWeeks?[6],
                        plan.PlanWeeks?[7]);
                });
                
            }
        }

        public void Update(int rowIndex)
        {
            if (!IsValid(rowIndex)) return;
            var hPlan = UpdatedData.DataRowToData[_mainGrid.Rows[rowIndex]];

            if (int.TryParse(_mainGrid[0, rowIndex].Value.ToString(), out int hPlanId) &&
                int.TryParse(_mainGrid[1, rowIndex].Value.ToString(), out int subjectId))
            {
                hPlan.Id = hPlanId;
                hPlan.SubjectId = subjectId;
                hPlan.Code = _mainGrid[2, rowIndex].Value.ToString();
                for (int i = 3; i < 11; i++)
                {
                    if (int.TryParse(_mainGrid[i, rowIndex].Value.ToString(), out int val))
                        hPlan[i - 3] = val;
                }
                if (!UpdatedData.Updated.Contains(hPlan))
                    UpdatedData.Updated.Add(hPlan);
            }
                
        }

        private bool IsValid(int rowIndex)
        {
            for (int i = 0; i < 11; i++)
            {
                if (_mainGrid[i, rowIndex].Value is null)
                    return false;
            }
            return true;
        }
    }
}
