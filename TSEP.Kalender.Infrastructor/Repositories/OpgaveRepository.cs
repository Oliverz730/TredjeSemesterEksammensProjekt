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
            // Tilføj Opgave til databasen
            _db.OpgaveEntities.Add(opgave);
            // Gem ændringer i databasen
            _db.SaveChanges();
        }

        OpgaveQueryResultDto IOpgaveRepository.Get(int projektId, int opgaveTypeId, string ansatId)
        {
            //Find opgave med det givne projektId, opgaveId og ansatId
            var opgave = _db.OpgaveEntities.First(o =>
                o.ProjektId == projektId && o.OpgaveTypeId == opgaveTypeId && o.AnsatId == ansatId);
            //Hvis dette ikke er muligt throw exception ""
            if (opgave == null) throw new Exception("Opgave findes ikke");

            // Returner -konvertering fra Entity til OpgaveQueryResultDto
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

        IEnumerable<OpgaveQueryResultDto> IOpgaveRepository.GetAllByAnsat(string ansatId)
        {
            //Itterér over listen af opgaver, hvor givne asnatId matcher
            foreach (var opgave in _db.OpgaveEntities.Where(o => o.AnsatId == ansatId).AsNoTracking().ToList())
            {
                //Konverter fra Entity til OpgaveQueryResultDto, og yield hver enkeltvis
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

        IEnumerable<OpgaveQueryResultDto> IOpgaveRepository.GetAllByProjekt(int projektId)
        {
            //Itterér over listen af opgaver, hvor givne projektId matcher
            foreach (var opgave in _db.OpgaveEntities.Where(o => o.ProjektId == projektId).AsNoTracking().ToList())
            {
                //Konverter fra Entity til OpgaveQueryResultDto, og yield hver enkeltvis
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
