using TSEP.Igangsættelse.Application.Projekt.Repositories;

namespace TSEP.Igangsættelse.Application.Projekt.Queries.Implementation
{
    public class ProjektGetAllByKundeQuery : IProjektGetAllByKundeQuery
    {
        private readonly IProjektRepository _projektRepository;

        public ProjektGetAllByKundeQuery(IProjektRepository projektRepository)
        {
            _projektRepository = projektRepository;
        }

        IEnumerable<ProjektQueryResultDto> IProjektGetAllByKundeQuery.GetAllByKunde(string userId)
        {
            //Return de fundne projektdto, med givne kunde fra repository
            return _projektRepository.GetAllByKunde(userId);
        }
    }
}
