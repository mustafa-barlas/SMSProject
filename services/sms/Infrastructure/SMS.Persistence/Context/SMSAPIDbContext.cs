using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Entities.Common;

namespace SMS.Persistence.Context;

public class SMSAPIDbContext : DbContext
{
    public SMSAPIDbContext(DbContextOptions<SMSAPIDbContext> options) 
        : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<HomeWork> HomeWorks { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Module> Modules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433; Initial Catalog=SMSDb; User Id=sa; Password=201203011Aa.; TrustServerCertificate=True;");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

        var datas = ChangeTracker
            .Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}