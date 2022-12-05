using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSEP.Kalender.Domain.Model;

namespace TSEP.SqlDbContext.KalenderConfiguration
{
    public class OpgaveConfuguration : IEntityTypeConfiguration<OpgaveEntity>
    {
        public void Configure(EntityTypeBuilder<OpgaveEntity> builder)
        {
            builder.ToTable("Opgave", "opgave");

            builder.HasKey(x => x.ProjektId);
            builder.HasKey(x => x.OpgaveTypeId);
            builder.HasKey(x => x.AnsatId);
        }
    }
}
