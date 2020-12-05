using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.FormCommands.Receivers
{
    public class DataGridViewCommandReceiver
    {
        public DataGridView GridView { get; }
        public ITimetableViewData ViewData { get; }
        public DataGridViewCommandReceiver(DataGridView grid, ITimetableViewData data)
        {
            GridView = grid;
            ViewData = data;
        }

    }
}
