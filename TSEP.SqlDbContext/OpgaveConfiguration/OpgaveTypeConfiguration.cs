using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSEP.StamData.Domain.Model;

namespace TSEP.SqlDbContext.OpgaveConfiguration
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
