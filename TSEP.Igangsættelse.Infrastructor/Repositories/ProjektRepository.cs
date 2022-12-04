using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Igangsættelse.Application.Projekt.Repositories;
using TSEP.Igangsættelse.Application.Projekt.Queries;
using TSEP.SqlDbContext;
using TSEP.Igangsættelse.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace TSEP.Igangsættelse.Infrastructor.Repositories
{
    public class ProjektRepository : IProjektRepository
    {
        private readonly TredjeSemesterEksamensProjektContext _db;
        public ProjektRepository(TredjeSemesterEksamensProjektContext db)
        {
            _db = db;
        }
        void IProjektRepository.Add(ProjektEntity projekt)
        {
            _db.ProjektEntities.Add(projekt);
            _db.SaveChanges();
        }
        ProjektEntity IProjektRepository.Load(int id)
        {
            var projektEntity = _db.ProjektEntities.FirstOrDefault(x => x.Id == id);
            if (projektEntity == null) throw new Exception("Projekt findes ikke");

            return projektEntity;
        }
        ProjektQueryResultDto IProjektRepository.Get(int id, string userId)
        {
            var projektEntity = _db.ProjektEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            
            if (projektEntity == null) throw new Exception("Projekt findes ikke");
            if (projektEntity.SælgerUserId != userId) throw new Exception("Sælger har ikke lov til at se dette projekt"); 

            return new ProjektQueryResultDto
            {
                Id = projektEntity.Id,
                ProjektName = projektEntity.ProjektName,
                StartDate = projektEntity.StartDate,
                EndDate = projektEntity.EndDate,
                EstimatedTime = projektEntity.EstimatedTime,
                ActualEstimated = projektEntity.ActualEstimated,
                SælgerUserId = projektEntity.SælgerUserId,
                KundeUserId = projektEntity.KundeUserId,
                RowVersion = projektEntity.RowVersion,
            };
        }
        void IProjektRepository.Update(ProjektEntity projekt)
        {
            _db.ProjektEntities.Update(projekt);
            _db.SaveChanges();
        }
        IEnumerable<ProjektQueryResultDto> IProjektRepository.GetAll(string userId)
        {
            foreach (var projekt in _db.ProjektEntities.Where(pId => pId.SælgerUserId == userId).AsNoTracking().ToList())
            {
                //var ansatte = entity.Ansatte.Select(a => new KompetanceAnsatQueryResultDto { UserId = a.UserId});
                yield return new ProjektQueryResultDto { 
                    Id = projekt.Id, 
                    ProjektName = projekt.ProjektName,
                    StartDate = projekt.StartDate, 
                    EndDate = projekt.EndDate, 
                    EstimatedTime = projekt.EstimatedTime,
                    ActualEstimated = projekt.ActualEstimated,
                    SælgerUserId = projekt.SælgerUserId,
                    KundeUserId = projekt.KundeUserId,
                    RowVersion = projekt.RowVersion,
                };
            }
        }
    }
}
