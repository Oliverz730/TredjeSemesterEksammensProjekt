using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSEP.StamData.Domain.Model;

namespace TSEP.SqlDbContext.OpgaveConfiguration
{
    public class KompetanceTypeConfiguration : IEntityTypeConfiguration<KompetanceEntity>
    {
        public void Configure(EntityTypeBuilder<KompetanceEntity> builder)
        {
            builder.ToTable("Kompetance", "kompetance");

            builder.HasKey(x => x.Id);
        }
    }
}
