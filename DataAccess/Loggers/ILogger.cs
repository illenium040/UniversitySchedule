using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Loggers
{
    public interface ILogger
    {
        void Log(string message);
        Task LogAsync(string message);
    }
}
