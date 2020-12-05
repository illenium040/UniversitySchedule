using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.FormCommands
{
    public class CommandInvoker<TCommand>
        where TCommand : ICommand
    {
        private TCommand _command;
        public CommandInvoker<TCommand> SetCommand(TCommand command)
        {
            _command = command;
            return this;
        }
        public CommandInvoker<TCommand> Run()
        {
            _command.Execute();
            return this;
        }
    }
}
