using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Igangsættelse.Application.Projekt.Repositories;

namespace TSEP.Igangsættelse.Application.Projekt.Queries.Implementation
{
    public class ProjektGetAllQuery : IProjektGetAllQuery
    {
        private readonly IProjektRepository _projektRepository;

        public ProjektGetAllQuery(IProjektRepository projektRepository)
        {
            _projektRepository = projektRepository;
        }

        IEnumerable<ProjektQueryResultDto> IProjektGetAllQuery.GetAll(string userId)
        {
            return _projektRepository.GetAll(userId);
        }
    }
}
