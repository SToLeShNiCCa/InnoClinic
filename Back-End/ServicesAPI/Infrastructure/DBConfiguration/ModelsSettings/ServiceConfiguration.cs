using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore; // Add this using directive

namespace Infrastructure.DBConfiguration.ModelsSettings
{
    public class ServiceConfiguration : EntityConfiguration<Service>
    {
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.ServiceCategoryId)
                .IsRequired();

            builder.Property(s => s.ServiceName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Price)
                .IsRequired();

            builder.Property(s => s.SpecializationId)
                .IsRequired();

            builder.Property(s => s.IsActive)
                .IsRequired();
        }
    }
}
