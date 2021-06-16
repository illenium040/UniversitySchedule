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
        protected void AppendDaysOfWeek(TimetableViewInfo view)
        {
            for (int i = view.Days * view.Hours - view.Hours, j = view.Days; i >= 0; i -= view.Hours, j--)
            {
                if (Receiver.GridView.InvokeRequired)
                    Receiver.GridView.Invoke((grid) => Invoke(grid, i, j));
                else Invoke(Receiver.GridView, i, j);
            }
        }

        private void Invoke(DataGridView grid, int i, int j)
        {
            grid.Rows.Insert(i, 1);
            for (int col = 0; col < grid.Columns.Count; col++)
                grid[col, i].Value = WinFormStaticHelper.GetRuDayOfWeek(j - 1);
        }

        public abstract void Execute();
        public virtual DataGridViewCommand AddReceiver(DataGridViewCommandReceiver receiver)
        {
            Receiver = receiver;
            GridVisualizer = new GridVisualizer(receiver.GridView);
            return this;
        }
    }
}
