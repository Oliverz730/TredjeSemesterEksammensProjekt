﻿using TSEP.StamData.Application.Ansat.Repositories;

namespace TSEP.StamData.Application.Ansat.Queries.Implementation
{
    public class AnsatGetAllQuery : IAnsatGetAllQuery
    {
        private readonly IAnsatRepository _ansatRepository;

        public AnsatGetAllQuery(IAnsatRepository ansatRepository)
        {
            _ansatRepository = ansatRepository;
        }
        IEnumerable<AnsatQueryResultDto> IAnsatGetAllQuery.GetAll()
        {
            return _ansatRepository.GetAll();
        }
    }
}
