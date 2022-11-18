using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TredjeSemesterEksamensProjekt.StamData.Domain.Model;

namespace TredjeSemesterEksamensProjekt.SqlDbContextProjekt.OpgaveConfiguration
{
    public class OpgaveTypeConfiguration : IEntityTypeConfiguration<OpgaveEntity>
    {
        public void Configure(EntityTypeBuilder<OpgaveEntity> builder)
        {
            builder.ToTable("Opgave", "opgave");

            builder.HasKey(x => x.Id);
        }
    }
}
