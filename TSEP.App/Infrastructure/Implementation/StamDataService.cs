﻿using TSEP.App.Infrastructure.Contract;
using TSEP.App.Infrastructure.Contract.Dto;

namespace TSEP.App.Infrastructure.Implementation
{
    public class StamDataService : IStamDataService
    {
        private readonly HttpClient _httpClient;

        public StamDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IStamDataService.CreateAnsat(AnsatCreateRequestDto ansatCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/Ansat", ansatCreateRequestDto);
        }

        async Task IStamDataService.CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/Kompetance", kompetanceCreateRequestDto);
        }

        async Task IStamDataService.EditAnsat(AnsatEditRequestDto ansatEditRequestDto)
        {
            var res = await _httpClient.PutAsJsonAsync($"api/Ansat", ansatEditRequestDto);
        }

        async Task IStamDataService.EditKompetance(KompetanceEditRequestDto kompetanceEditRequestDto)
        {
            var res = await _httpClient.PutAsJsonAsync($"api/Kompetance", kompetanceEditRequestDto);
        }

        async Task<IEnumerable<KompetanceQueryResultDto>?> IStamDataService.GetAllKompetance()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<KompetanceQueryResultDto>>($"api/Kompetance");
        }

        async Task<AnsatQueryResultDto?> IStamDataService.GetAnsat(string userId)
        {
            return await _httpClient.GetFromJsonAsync<AnsatQueryResultDto>($"api/Ansat/" + userId);
        }
    }
}