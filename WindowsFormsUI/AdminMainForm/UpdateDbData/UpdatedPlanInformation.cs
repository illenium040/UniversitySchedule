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
    public class UpdatedPlanInformation : IUpdateData<PlanInformation>, 
        IUpdatedDataExtraRepo<Specialty>
    {
        public UpdatedData<PlanInformation> UpdatedData { get; }

        private ISpecialtyRepository _specialtyRepo;
        private DataGridView _mainGrid;
        private DataGridView _subGrid;

        public UpdatedPlanInformation(DataGridView mainGrid, DataGridView subGrid)
        {
            UpdatedData = new UpdatedData<PlanInformation>();
            _mainGrid = mainGrid;
            _subGrid = subGrid;
        }

        public void Add()
        {
            var plan = new PlanInformation()
            {
                HourPlans = new List<HourPlan>(),
                PlanWeeks = new PlanWeek(),
            };
            UpdatedData.Added.Add(plan);
            foreach (DataGridViewRow row in _mainGrid.Rows)
            {
                if (!UpdatedData.DataRowToData.ContainsKey(row))
                {
                    UpdatedData.DataRowToData.Add(row, plan);
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
            try
            {
                UpdatedData.Check();
                foreach (var item in UpdatedData.Added)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
                    if (!IsValid(k.Index))
                    {
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Информация о планах\r\nНеобходимо заполнить все необходимые поля");
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
                        WinFormStaticHelper.ShowErrorMsgBox("Таблица: Информация о планах\r\nНеобходимо заполнить все необходимые поля");
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

        public void SetGrid(IRepository<PlanInformation> repo)
        {
            _mainGrid.Invoke(g =>
            {
                g.Columns.Add("ID", "ID");
                g.Columns.Add("PlanYear", "Год создания плана");
                g.Columns.Add("StudyForm", "Форма обучения");
                g.Columns.Add("SpecialtyID", "ID специальности");
                for (int i = 0; i < 8; i++)
                    g.Columns.Add($"Weeks{i + 1}", $"Недели на семестр {i + 1}");
                foreach (var plan in repo.GetAll())
                {

                    var index = g.Rows.Add(plan.Id, 
                        plan.PlanYear,
                        plan.StudyForm, 
                        plan.SpecialtyId,
                            plan.PlanWeeks?[0],
                            plan.PlanWeeks?[1],
                            plan.PlanWeeks?[2],
                            plan.PlanWeeks?[3],
                            plan.PlanWeeks?[4],
                            plan.PlanWeeks?[6],
                            plan.PlanWeeks?[5],
                            plan.PlanWeeks?[7]);
                    UpdatedData.DataRowToData.Add(g.Rows[index], plan);
                }
            });
            _subGrid.Invoke(g =>
            {
                if (_specialtyRepo != null)
                {
                    g.Columns.Add("ID", "ID");
                    g.Columns.Add("Индекс", "Индекс");
                    g.Columns.Add("Наименование", "Наименование");
                    g.Columns.Add("Группы", "Группы");
                    foreach (var specialty in _specialtyRepo.GetAll())
                    {
                        g.Rows.Add(specialty.Id,
                            specialty.Index,
                            specialty.Name,
                            CombineGroupsList(specialty.Groups));
                    }
                }
            });
            
        }

        private string CombineGroupsList(List<Group> groups)
        {
            var str = new StringBuilder();
            foreach (var g in groups)
                str.Append($"{g.Id};");
            return str.ToString();
        }

        public void Update(int rowIndex)
        {
            if (!IsValid(rowIndex)) return;
            var plan = UpdatedData.DataRowToData[_mainGrid.Rows[rowIndex]];
            if (int.TryParse(_mainGrid[0, rowIndex].Value.ToString(), out int planId) &&
                int.TryParse(_mainGrid[3, rowIndex].Value.ToString(), out int specialtyId) &&
                int.TryParse(_mainGrid[1, rowIndex].Value.ToString(), out int year))
            {
                plan.Id = planId;
                plan.SpecialtyId = specialtyId;
                plan.PlanWeeks.Id = planId;
                plan.PlanYear = year;
                plan.StudyForm = _mainGrid[2, rowIndex].Value.ToString();
                plan.PlanWeeks.Id = planId;
                plan.PlanWeeks.PlanInformation = plan;
                for (int i = 4; i < 12; i++)
                {
                    if (int.TryParse(_mainGrid[i, rowIndex].Value.ToString(), out int val))
                        plan.PlanWeeks[i - 4] = val;
                }
                if (!UpdatedData.Updated.Contains(plan))
                    UpdatedData.Updated.Add(plan);
            }
        }

        public void SetExtraRepo(IRepository<Specialty> repo)
        {
            _specialtyRepo = repo as ISpecialtyRepository;
        }

        private bool IsValid(int rowIndex)
        {
            for (int i = 0; i < 12; i++)
            {
                if (_mainGrid[i, rowIndex].Value is null)
                    return false;
            }
            return true;
        }
    }
}
