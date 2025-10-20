using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DBConfiguration.ModelsSettings
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey("Id");

            builder.Property("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            ConfigureAdditionalProperties(builder);
        }

        protected abstract void ConfigureAdditionalProperties(EntityTypeBuilder<T> builder);
    }
}
