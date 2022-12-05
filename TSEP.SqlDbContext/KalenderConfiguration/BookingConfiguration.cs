using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TSEP.Kalender.Domain.Model;

namespace TSEP.SqlDbContext.KalenderConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("Booking", "booking");

            builder.HasKey(x => x.Id);
        }
    }
}
