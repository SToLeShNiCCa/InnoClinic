using Infrastructure.DbConfigurations.Contexts;
using Infrastructure.DBSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Migrations.MSSQL
{
    /// <summary>
    /// Class <c>InnoClinicDBContextFactory</c> is factory for DB context for migrations.
    /// </summary>
    public class ProfilesContextFactory : IDesignTimeDbContextFactory<ProfilesContext>
    {
        private readonly DataBaseSettings _databaseSettings;

        public ProfilesContextFactory(IOptions<DataBaseSettings> options)
        {
            _databaseSettings = options.Value;
        }
        /// <summary>
        /// Factory method for creating a new instance of InnoClinicDBContext with specified options.
        /// </summary>
        /// <param name="args">empty</param>
        /// <returns>DB context with new options</returns>
        public ProfilesContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ProfilesContext>()
                .UseSqlServer(
                _databaseSettings.ConnectionString,
                b => b.MigrationsAssembly(typeof(ProfilesContextFactory).Assembly.FullName));

            return new ProfilesContext(optionBuilder.Options);
        }
    }
}
