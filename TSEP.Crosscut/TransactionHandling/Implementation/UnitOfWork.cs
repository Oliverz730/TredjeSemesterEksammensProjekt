using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace TSEP.Crosscut.TransactionHandling.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        void IUnitOfWork.BeginTransaction(IsolationLevel isolationlevel)
        {
            _transaction = _db.Database.CurrentTransaction ?? _db.Database.BeginTransaction(isolationlevel);
        }

        void IUnitOfWork.Commit()
        {
            _transaction.Commit();
            _transaction.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
