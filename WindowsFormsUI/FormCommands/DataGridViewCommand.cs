using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI.FormCommands
{
    public abstract class DataGridViewCommand : ICommand
    {
        protected DataGridViewCommandReceiver Receiver;
        protected GridVisualizer GridVisualizer;
        public DataGridViewCommand(DataGridViewCommandReceiver receiver)
        {
            Receiver = receiver;
            GridVisualizer = new GridVisualizer(receiver.GridView);
        }

        protected void AppendDaysOfWeek(TimetableViewInfo view)
        {
            for (int i = view.Days * view.Hours - view.Hours, j = view.Days; i >= 0; i -= view.Hours, j--)
                Receiver.GridView.Invoke((grid) =>
                {
                    grid.Rows.Insert(i, 1);
                    for (int col = 0; col < grid.Columns.Count; col++)
                        grid[col, i].Value = IdkHelper.GetRuDayOfWeek(j - 1);
                });
        }
        public abstract void Execute();
    }
}
