using TSEP.App.Infrastructure.Kalender.Contract;
using TSEP.App.Infrastructure.Kalender.Contract.Dto;

namespace TSEP.App.Infrastructure.Kalender.Implementation
{
    public class KalenderService : IKalenderService
    {
        private readonly HttpClient _httpClient;

        public KalenderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IKalenderService.CreateBooking(BookingCreateRequestDto bookingCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/Booking", bookingCreateRequestDto);

            if (res.IsSuccessStatusCode) return;

            var message = await res.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IKalenderService.CreateOpgave(OpgaveCreateRequestDto opgaveCreateRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"api/Opgave", opgaveCreateRequestDto);

            if (res.IsSuccessStatusCode) return;

            var message = await res.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task<IEnumerable<BookingQueryResultDto>?> IKalenderService.GetAllBookings()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BookingQueryResultDto>>($"api/Booking");
        }

        async Task<IEnumerable<OpgaveQueryResultDto>> IKalenderService.GetAllOpgaverByProjekt(int projektId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OpgaveQueryResultDto>>($"api/Opgave/Projekt/{projektId}");
        }
        async Task<IEnumerable<OpgaveQueryResultDto>> IKalenderService.GetAllOpgaverByAnsat(string userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OpgaveQueryResultDto>>($"api/Opgave/Ansat/{userId}");
        }
    }
}
