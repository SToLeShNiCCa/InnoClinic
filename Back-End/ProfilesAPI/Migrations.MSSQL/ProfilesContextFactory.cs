using Infrastructure.DbConfigurations.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations.MSSQL
{
    /// <summary>
    /// Class <c>InnoClinicDBContextFactory</c> is factory for DB context for migrations.
    /// </summary>
    public class ProfilesContextFactory : IDesignTimeDbContextFactory<ProfilesContext>
    {
        /// <summary>
        /// Factory method for creating a new instance of InnoClinicDBContext with specified options.
        /// </summary>
        /// <param name="args">empty</param>
        /// <returns>DB context with new options</returns>
        public ProfilesContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ProfilesContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ProfilesAPI;Trusted_Connection=True;TrustServerCertificate=True;",
                b => b.MigrationsAssembly(typeof(ProfilesContextFactory).Assembly.FullName));

            return new ProfilesContext(optionBuilder.Options);
        }
    }
}
