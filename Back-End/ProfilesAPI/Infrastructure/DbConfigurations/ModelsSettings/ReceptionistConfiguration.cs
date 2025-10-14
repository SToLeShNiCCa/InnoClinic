using Domain.DBServices.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfigurations.ModelsSettings
{
    /// <summary>
    /// Receptionists table configuration class.
    /// </summary>
    public class ReceptionistConfiguration : EntityConfuguration<Receptionist>
    {
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Receptionist> builder)
        {
        }
    }
}
