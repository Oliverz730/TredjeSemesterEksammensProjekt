using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Opgave.Query;
using TSEP.Kalender.Application.Opgave.Repositories;
using TSEP.Kalender.Domain.Model;
using TSEP.SqlDbContext;

namespace TSEP.Kalender.Infrastructor.Repositories
{
    public class OpgaveRepository : IOpgaveRepository
    {
        private readonly TredjeSemesterEksamensProjektContext _db;

        public OpgaveRepository(TredjeSemesterEksamensProjektContext db)
        {
            _db = db;
        }

        void IOpgaveRepository.Add(OpgaveEntity opgave)
        {
            throw new NotImplementedException();
        }

        OpgaveQueryResultDto IOpgaveRepository.Get(int projektId, int opgaveTypeId, int ansatId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<OpgaveQueryResultDto> IOpgaveRepository.GetAll(int projektId)
        {
            throw new NotImplementedException();
        }
    }
}
