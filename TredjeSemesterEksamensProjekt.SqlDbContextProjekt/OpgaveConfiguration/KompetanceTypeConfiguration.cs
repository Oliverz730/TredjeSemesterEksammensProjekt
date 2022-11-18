using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TredjeSemesterEksamensProjekt.StamData.Domain.Model;

namespace TredjeSemesterEksamensProjekt.SqlDbContextProjekt.OpgaveConfiguration
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
