using TredjeSemesterEksammensProjekt.Infrastructure.Contract.Dto;
using TredjeSemesterEksammensProjekt.Infrastructure.Contract;

namespace TredjeSemesterEksammensProjekt.Infrastructure.Implementation
{
    public class StamDataService : IStamDataService
    {
        private readonly HttpClient _httpClient;

        public StamDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IStamDataService.CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/Kompetance", kompetanceCreateRequestDto);
        }
    }
}
