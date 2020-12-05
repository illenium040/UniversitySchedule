using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.FormCommands
{
    public abstract class DataGridViewCommand : IWinFormCommand<GridVisualizer>
    {
        protected DataGridViewCommandReceiver Receiver;
        public DataGridViewCommand(DataGridViewCommandReceiver receiver)
        {
            Receiver = receiver;
        }

        public abstract GridVisualizer Execute();
    }
}
