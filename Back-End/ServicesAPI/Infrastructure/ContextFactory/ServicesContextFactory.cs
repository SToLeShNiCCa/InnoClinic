using Infrastructure.DBConfiguration.DBSettings;
using Infrastructure.DBConfiguration.ServiceContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.DBConfiguration
{
    public class ServicesContextFactory : IDesignTimeDbContextFactory<ServicesContext>
    {
        private readonly DataBaseSettings _connection;

        public ServicesContextFactory(DataBaseSettings connection)
        {
            _connection = connection;
        }

        public ServicesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServicesContext>();

            optionsBuilder.UseSqlServer(_connection.ConnectionString,
                op => op.MigrationsAssembly(typeof(ServicesContextFactory).Assembly.FullName));

            return new ServicesContext(optionsBuilder.Options);
        }
    }
}
