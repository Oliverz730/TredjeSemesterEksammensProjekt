using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSEP.StamData.Domain.Model;

namespace TSEP.SqlDbContext.OpgaveConfiguration
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
