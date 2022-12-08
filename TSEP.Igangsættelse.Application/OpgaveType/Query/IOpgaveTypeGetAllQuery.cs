using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.Igangsættelse.Application.OpgaveType.Query
{
    public interface IOpgaveTypeGetAllQuery
    {
        IEnumerable<OpgaveTypeQueryResultDto> GetAll();
    }
}
