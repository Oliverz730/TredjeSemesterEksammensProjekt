﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Booking.Query
{
    public interface IBookingGetAllQuery
    {
        IEnumerable<BookingQueryResultDto> GetAll();
    }
}