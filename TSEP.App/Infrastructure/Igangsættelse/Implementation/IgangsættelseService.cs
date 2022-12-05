using TSEP.App.Infrastructure.Igangsættelse.Contract;
using TSEP.App.Infrastructure.Igangsættelse.Contract.Dto;

namespace TSEP.App.Infrastructure.Igangsættelse.Implementation
{
    public class IgangsættelseService : IIgangsættelseService
    {
        private readonly HttpClient _httpClient;

        public IgangsættelseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IIgangsættelseService.CreateOpgaveType(OpgaveTypeCreateRequestDto opgaveTypeCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/OpgaveType", opgaveTypeCreateRequestDto);

            if (res.IsSuccessStatusCode) return;

            var message = await res.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IIgangsættelseService.CreateProjekt(ProjektCreateRequestDto projektCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/Projekt", projektCreateRequestDto);

            if (res.IsSuccessStatusCode) return;

            var message = await res.Content.ReadAsStringAsync();
            throw new Exception(message);
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
