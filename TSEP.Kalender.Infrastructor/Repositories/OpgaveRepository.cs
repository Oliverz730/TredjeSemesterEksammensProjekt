using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            _db.OpgaveEntities.Add(opgave);
            _db.SaveChanges();
        }

        OpgaveQueryResultDto IOpgaveRepository.Get(int projektId, int opgaveTypeId, int ansatId)
        {
            var opgave = _db.OpgaveEntities.First(o =>
                o.ProjektId == projektId && o.OpgaveTypeId == opgaveTypeId && o.AnsatId == ansatId);
            if (opgave == null) throw new Exception("Opgave findes ikke");

            return new OpgaveQueryResultDto
            {
                ProjektId = opgave.ProjektId,
                OpgaveTypeId = opgave.OpgaveTypeId,
                AnsatId = opgave.AnsatId,
                RowVersion = opgave.RowVersion,
                Status = opgave.Status,
                StartTid = opgave.StartTid,
                SlutTid = opgave.SlutTid,
            };

        }

        IEnumerable<OpgaveQueryResultDto> IOpgaveRepository.GetAll(int projektId)
        {
            foreach (var opgave in _db.OpgaveEntities.Where(o => o.ProjektId == projektId).AsNoTracking().ToList())
            {
                yield return new OpgaveQueryResultDto
                {
                    ProjektId = opgave.ProjektId,
                    OpgaveTypeId = opgave.OpgaveTypeId,
                    AnsatId = opgave.AnsatId,
                    RowVersion = opgave.RowVersion,
                    Status = opgave.Status,
                    StartTid = opgave.StartTid,
                    SlutTid = opgave.SlutTid,
                };
            }
        }
    }
}
