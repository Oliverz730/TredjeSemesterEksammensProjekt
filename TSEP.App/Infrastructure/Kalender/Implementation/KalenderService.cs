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
        async Task<IEnumerable<BookingQueryResultDto>?> IKalenderService.GetAllBookings()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BookingQueryResultDto>>($"api/Booking");
        }
    }
}
