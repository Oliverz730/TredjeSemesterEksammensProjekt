using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Igangsættelse.Application.Projekt.Queries;
using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.Igangsættelse.Application.Projekt.Repositories
{
    public interface IProjektRepository
    {
        void Add(ProjektEntity kompetance);
        ProjektEntity Load(int id);
        ProjektQueryResultDto Get(int id);
        IEnumerable<ProjektQueryResultDto> GetAll();


        void Update(ProjektEntity projekt);
    }
}
