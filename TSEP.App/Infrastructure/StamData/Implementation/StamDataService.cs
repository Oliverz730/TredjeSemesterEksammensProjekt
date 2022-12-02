using TSEP.App.Infrastructure.StamData.Contract;
using TSEP.App.Infrastructure.StamData.Contract.Dto;

namespace TSEP.App.Infrastructure.StamData.Implementation
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

            if (res.IsSuccessStatusCode) return;

            var message = await res.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IStamDataService.CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/Kompetance", kompetanceCreateRequestDto);

            if (res.IsSuccessStatusCode) return;

            var message = await res.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IStamDataService.EditAnsat(AnsatEditRequestDto ansatEditRequestDto)
        {
            var res = await _httpClient.PutAsJsonAsync($"api/Ansat", ansatEditRequestDto);

            if (res.IsSuccessStatusCode) return;

            var message = await res.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<KompetanceQueryResultDto> IStamDataService.GetKompetance(int id)
        {
            return await _httpClient.GetFromJsonAsync<KompetanceQueryResultDto>($"api/Kompetance/{id}");
        }

        async Task IStamDataService.EditKompetance(KompetanceEditRequestDto kompetanceEditRequestDto)
        {
            var res = await _httpClient.PutAsJsonAsync($"api/Kompetance", kompetanceEditRequestDto);

            if (res.IsSuccessStatusCode) return;

            var message = await res.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<IEnumerable<KompetanceQueryResultDto>?> IStamDataService.GetAllKompetance()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<KompetanceQueryResultDto>>($"api/Kompetance");
        }

        async Task<AnsatQueryResultDto?> IStamDataService.GetAnsat(string userId)
        {
            return await _httpClient.GetFromJsonAsync<AnsatQueryResultDto>($"api/Ansat/{userId}");
        }
    }
}
