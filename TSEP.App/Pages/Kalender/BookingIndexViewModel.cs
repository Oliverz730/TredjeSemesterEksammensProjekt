namespace TSEP.App.Pages.Kalender
{
    public class BookingIndexViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] Rowversion { get; set; }
        public string AnsatNavn { get; set; }
    }
}
