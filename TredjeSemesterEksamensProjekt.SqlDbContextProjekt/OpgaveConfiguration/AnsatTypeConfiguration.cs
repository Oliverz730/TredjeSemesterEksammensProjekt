using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TredjeSemesterEksamensProjekt.StamData.Domain.Model;

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
