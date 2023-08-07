

using DomainModels.Entities;
using DomainModels.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiddelLayer.EntitiesConfigurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors").HasKey(x => x.Id);

            builder.Property(x => x.contact).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.license).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.specialty)
                                           .HasConversion(
                                               v => v.ToString(),
                                               v => (Specialty)Enum.Parse(typeof(Specialty), v)
                                           );


        }
    }
}
