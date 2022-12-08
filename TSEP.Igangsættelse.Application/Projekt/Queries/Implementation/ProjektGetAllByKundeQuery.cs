using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return _projektRepository.GetAllByKunde(userId);
        }
    }
}
