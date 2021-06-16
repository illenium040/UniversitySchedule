using DataAccess.Entities;
using DataAccess.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm.UpdateDbData
{
    public class UpdatedTimetable : IUpdateData<TimetableViewInfo>
    {
        public UpdatedData<TimetableViewInfo> UpdatedData { get; }

        private DataGridView _mainGrid;
        public UpdatedTimetable(DataGridView mainGrid)
        {
            _mainGrid = mainGrid;
            UpdatedData = new UpdatedData<TimetableViewInfo>();
        }

        public void Add() {  }

        public void Remove(DataGridViewRow row)
        {
            UpdatedData.Removed.Add(UpdatedData.DataRowToData[row]);
            UpdatedData.DataRowToData.Remove(row);
        }

        public bool Save(IRepository<TimetableViewInfo> repo)
        {
            try
            {
                UpdatedData.Check();
                foreach (var item in UpdatedData.Removed)
                    repo.Remove(item);
                foreach (var item in UpdatedData.Updated)
                {
                    var k = UpdatedData.DataRowToData.First(x => x.Value.Equals(item)).Key;
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

        public void SetGrid(IRepository<TimetableViewInfo> repo)
        {
            _mainGrid.Clear();
            _mainGrid.Invoke(g =>
            {
                g.Columns.Add("ID", "ID");
                g.Columns.Add("Время создания", "DateTime");
                g.Columns.Add("Подтверждение", "IsVerified");
                g.Columns.Add("кол-во дней", "Days");
                g.Columns.Add("Кол-во часов", "Hours");
                g.Columns.Add("Оценка", "Mark");
            });
            foreach (var tInfo in repo.GetAll())
            {
                _mainGrid.Invoke(g =>
                {
                    var index = g.Rows.Add(tInfo.Id, tInfo.DateTime, tInfo.IsVerified ? 1 : 0,
                        tInfo.Days, tInfo.Hours, tInfo.Mark);
                    UpdatedData.DataRowToData.Add(g.Rows[index], tInfo);
                });
            }
            
        }

        public void Update(int rowIndex)
        {
            var info = UpdatedData.DataRowToData[_mainGrid.Rows[rowIndex]];
            var str = _mainGrid[2, rowIndex].Value?.ToString();
            if (str == "1" || str == "0")
                info.IsVerified = str == "1" ? true : false;
            if (!UpdatedData.Updated.Contains(info))
                UpdatedData.Updated.Add(info);
        }
    }
}
