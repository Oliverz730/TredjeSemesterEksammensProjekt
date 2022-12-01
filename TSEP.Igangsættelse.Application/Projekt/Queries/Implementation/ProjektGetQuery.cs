using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        ProjektQueryResultDto IProjektGetQuery.Get(int id)
        {
            var projektDto = _projektRepository.Get(id);

            return projektDto;
        }
    }
}
