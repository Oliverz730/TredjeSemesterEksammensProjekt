using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Domain.DomainServices
{
    public interface IBookingDomainService
    {
        bool BookingExsistsOnDate(DateTime startDate, DateTime endDate);
    }
}
