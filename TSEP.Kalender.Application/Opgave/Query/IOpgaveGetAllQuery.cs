﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Opgave.Query
{
    public interface IOpgaveGetAllQuery
    {
        public IEnumerable<OpgaveQueryResultDto> GetAll(int projektId);
    }
}
