using Microsoft.EntityFrameworkCore;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
