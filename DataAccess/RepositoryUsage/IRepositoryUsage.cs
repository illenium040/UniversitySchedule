using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryUsage
{
    public interface IRepositoryUsage : IDisposable
    {
        int Complete();
    }
}
