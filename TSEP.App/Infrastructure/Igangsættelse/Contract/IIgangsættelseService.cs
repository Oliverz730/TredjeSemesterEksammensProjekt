﻿using TSEP.App.Infrastructure.Igangsættelse.Contract.Dto;

namespace TSEP.App.Infrastructure.Igangsættelse.Contract
{
    public interface IIgangsættelseService
    {
        Task CreateOpgaveType(OpgaveTypeCreateRequestDto opgaveTypeCreateRequestDto);

        Task CreateProjekt(ProjektCreateRequestDto projektCreateRequestDto);
        Task<IEnumerable<ProjektQueryResultDto>?> GetAllProjekt(string userId);
        Task<ProjektQueryResultDto?> GetProjekt(int id, string userId);
        Task EditProjekt(ProjektEditRequestDto projektEditRequestDto);

    }
}
