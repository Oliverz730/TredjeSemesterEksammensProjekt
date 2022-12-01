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
    }
}
