
using TSEP.Igangsættelse.Application.Projekt.Repositories;

namespace TSEP.Igangsættelse.Application.Projekt.Queries.Implementation
{
    public class ProjektGetQuery : IProjektGetQuery
    {
        private readonly IProjektRepository _projektRepository;

        public ProjektGetQuery(IProjektRepository projektRepository)
        {
            _projektRepository = projektRepository;
        }

        ProjektQueryResultDto IProjektGetQuery.Get(int id, string userId)
        {
            //Hent projektQueryResultDto fra Repository
            var projektDto = _projektRepository.Get(id, userId);

            //Returnerer den fundne projektQueryResultDto
            return projektDto;
        }
    }
}
