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
        int IProjektRepository.Add(ProjektEntity projekt)
        {
            //Tilføj projekt til databasen
            _db.ProjektEntities.Add(projekt);
            //Gem ændringer i databasen
            _db.SaveChanges();
            // Returner id for projekt
            return projekt.Id;
        }
        ProjektEntity IProjektRepository.Load(int id)
        {
            // Find projekt med givne id
            var projektEntity = _db.ProjektEntities.FirstOrDefault(x => x.Id == id);
            //hvis ikke projektet findes, throw exception ""
            if (projektEntity == null) throw new Exception("Projekt findes ikke");
            //Returner projekt, som blev fundet
            return projektEntity;
        }
        ProjektQueryResultDto IProjektRepository.Get(int id, string userId)
        {
            //Indlæs data baseret på id
            var projektEntity = _db.ProjektEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);

            //hvis ikke projektet findes, throw exception ""
            if (projektEntity == null) throw new Exception("Projekt findes ikke");
            // Hvis ikke sælgerId matcher brugerid, throw exeption "" -Ikke brugerens projekt
            if (projektEntity.SælgerUserId != userId) throw new Exception("Sælger har ikke lov til at se dette projekt"); 

            //Konverter fra entity til dto
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
            //updater projekt i databasen
            _db.ProjektEntities.Update(projekt);
            //Gem ændringer i databasen på projekt
            _db.SaveChanges();
        }
        IEnumerable<ProjektQueryResultDto> IProjektRepository.GetAll(string userId)
        {
            //iterer over projekt hvor sælgerid matcher userid
            foreach (var projekt in _db.ProjektEntities.Where(pId => pId.SælgerUserId == userId).AsNoTracking().ToList())
            {
                //Konverter fra entitet til dto, yield hver enkeltvis

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

        IEnumerable<ProjektQueryResultDto> IProjektRepository.GetAllByKunde(string userId)
        {
            foreach (var projekt in _db.ProjektEntities.Where(pId => pId.KundeUserId == userId).AsNoTracking().ToList())
            {
                //var ansatte = entity.Ansatte.Select(a => new KompetanceAnsatQueryResultDto { UserId = a.UserId});
                yield return new ProjektQueryResultDto
                {
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
