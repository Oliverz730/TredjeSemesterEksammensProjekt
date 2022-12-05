using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.SqlDbContext.IgangsættelseConfiguration
{
    public class ProjektConfuguration : IEntityTypeConfiguration<ProjektEntity>
    {
        public void Configure(EntityTypeBuilder<ProjektEntity> builder)
        {
            builder.ToTable("Projekt", "projekt");

            builder.HasKey(x => x.Id);
        }
    }
}
