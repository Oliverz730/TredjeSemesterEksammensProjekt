namespace TSEP.App.Pages.Booking
{
    public class BookingCreateViewModel
    {
        public int ProjektId { get;  set; }
        public int OpgaveTypeId { get;  set; }
        public int AnsatId { get;  set; }
        public string Status { get;  set; }
        public DateTime StartTid { get;  set; }
        public DateTime SlutTid { get;  set; }
    }
}
