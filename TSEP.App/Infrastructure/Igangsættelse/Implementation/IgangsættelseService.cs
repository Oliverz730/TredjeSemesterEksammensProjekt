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
    }
}
