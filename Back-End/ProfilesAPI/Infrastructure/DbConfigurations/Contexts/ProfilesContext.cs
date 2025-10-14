using Domain.DBServices.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations.Contexts
{
    /// <summary>
    /// Class <c>InnoClinicDBContext</c> is context for DB.
    /// </summary>
    public class ProfilesContext : DbContext
    {
        public ProfilesContext(DbContextOptions options) 
            : base(options)
        {
        }

        /// <summary>
        /// Initialization of Doctors table.
        /// </summary>
        public DbSet<Doctor> Doctors { get; set; }

        /// <summary>
        /// Initialization of Receptionists table.
        /// </summary>
        public DbSet<Receptionist> Receptionists { get; set; }

        /// <summary>
        /// Initialization of Patients table.
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Method <c>OnModelCreating</c> is used to configure the model that was discovered by convention from the entity types
        /// </summary>
        /// <param name="modelBuilder">Class which give opportunity for set up tables settings</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
