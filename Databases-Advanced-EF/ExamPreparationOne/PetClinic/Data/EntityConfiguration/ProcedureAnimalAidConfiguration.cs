using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data.EntityConfiguration
{
    public class ProcedureAnimalAidConfiguration : IEntityTypeConfiguration<ProcedureAnimalAid>
    {
        public void Configure(EntityTypeBuilder<ProcedureAnimalAid> builder)
        {
            builder.HasKey(x => new {x.ProcedureId, x.AnimalAidId});

            builder.HasOne(x => x.AnimalAid)
                .WithMany(x => x.AnimalAidProcedures)
                .HasForeignKey(x => x.AnimalAidId);

            builder.HasOne(x => x.Procedure)
                .WithMany(x => x.ProcedureAnimalAids)
                .HasForeignKey(x => x.ProcedureId);
        }
    }
}
