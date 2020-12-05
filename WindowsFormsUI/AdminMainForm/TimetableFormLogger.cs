using DataAccess.Loggers;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm
{
    public class TimetableFormLogger : ILogger
    {
        private Label _logLabel;
        public TimetableFormLogger(Label label)
        {
            _logLabel = label;
        }
        public void Log(string message)
        {
            _logLabel.Invoke(()=> _logLabel.Text = message);
        }

        public Task LogAsync(string message)
        {
            Log(message);
            return Task.CompletedTask;
        }
    }
}
