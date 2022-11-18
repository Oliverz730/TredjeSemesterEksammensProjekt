using Microsoft.EntityFrameworkCore;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TredjeSemesterEksamensProjekt.SqlDbContextProjekt.OpgaveConfiguration
{
    internal class AnsatTypeConfiguration : IEntityTypeConfiguration<AnsatEntity>
    {
        public void Configure(EntityTypeBuilder<AnsatEntity> builder)
        {
            builder.ToTable("Ansat", "ansat");

            builder.HasKey(x => x.Id);
        }
    }
}
