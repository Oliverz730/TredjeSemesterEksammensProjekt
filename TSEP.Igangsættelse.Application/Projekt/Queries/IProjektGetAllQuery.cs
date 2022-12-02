using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Application.Projekt.Queries
{
    public interface IProjektGetAllQuery
    {
        IEnumerable<ProjektQueryResultDto> GetAll(string userId);
    }
}
