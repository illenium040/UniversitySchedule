using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.FormCommands
{
    public class DataGridViewCommandInvoker
    {
        private DataGridViewCommand _command;
        public DataGridViewCommandInvoker SetCommand(DataGridViewCommand command)
        {
            _command = command;
            return this;
        }

        public void Run()
        {
            _command.Execute();
        }
    }
}
