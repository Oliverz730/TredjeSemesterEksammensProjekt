using TSEP.App.Infrastructure.Contract;
using TSEP.App.Infrastructure.Contract.Dto;

namespace TSEP.App.Infrastructure.Implementation
{
    public class IgangsættelseService : IIgangsættelseService
    {
        private readonly HttpClient _httpClient;

        public IgangsættelseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        async Task IIgangsættelseService.CreateProjekt(ProjektCreateRequestDto projektCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/Projekt", projektCreateRequestDto);
        }
        async Task<IEnumerable<ProjektQueryResultDto>?> IIgangsættelseService.GetAllProjekt(string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProjektQueryResultDto>>($"api/Projekt/" + userId);
        }

        async Task<ProjektQueryResultDto?> IIgangsættelseService.GetProjekt(int id, string userId)
        {
            return await _httpClient.GetFromJsonAsync<ProjektQueryResultDto>($"api/Projekt/{id}/{userId}");
        }
        async Task IIgangsættelseService.EditProjekt(ProjektEditRequestDto projektEditRequestDto)
        {
            var res = await _httpClient.PutAsJsonAsync($"api/Projekt", projektEditRequestDto);
        }
    }
}
