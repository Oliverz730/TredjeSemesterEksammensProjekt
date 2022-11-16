using TredjeSemesterEksamensProjekt.Opgave.Application.Commands;
using TredjeSemesterEksammensProjekt.Infrastructure.Contract;

namespace TredjeSemesterEksammensProjekt.Infrastructure.Implementation
{
    public class OpgaveService : IOpgaveService
    {
        private readonly HttpClient _httpClient;

        public OpgaveService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IOpgaveService.CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto)
        {
            await _httpClient.PostAsJsonAsync<KompetanceCreateRequestDto>($"api/Opgave", kompetanceCreateRequestDto);
        }
    }
}
