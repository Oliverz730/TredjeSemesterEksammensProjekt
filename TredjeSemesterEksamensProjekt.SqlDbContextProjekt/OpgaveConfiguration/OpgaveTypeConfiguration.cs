using Microsoft.EntityFrameworkCore;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
