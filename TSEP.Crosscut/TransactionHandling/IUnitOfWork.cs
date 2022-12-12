using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Crosscut.TransactionHandling
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void BeginTransaction(IsolationLevel isolationlevel);
    }
}
