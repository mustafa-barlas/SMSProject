using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SMS.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SMSAPIDbContext>
    {
        public SMSAPIDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SMSAPIDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Initial Catalog=SMSDb;User Id=sa;Password=201203011Aa.;TrustServerCertificate=True;");

            return new SMSAPIDbContext(optionsBuilder.Options);
        }
    }
}
