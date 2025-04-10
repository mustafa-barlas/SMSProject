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
    public DbSet<StudentModule> StudentModules { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433; Initial Catalog=SMSDb; User Id=sa; Password=201203011Aa.; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Student - Module => Many-to-Many
        modelBuilder.Entity<StudentModule>()
            .HasKey(sm => new { sm.StudentId, sm.ModuleId });

        modelBuilder.Entity<StudentModule>()
            .HasOne(sm => sm.Student)
            .WithMany(s => s.StudentModules)
            .HasForeignKey(sm => sm.StudentId);

        modelBuilder.Entity<StudentModule>()
            .HasOne(sm => sm.Module)
            .WithMany(m => m.StudentModules)
            .HasForeignKey(sm => sm.ModuleId);


        // Module - Topic => One-to-Many
        modelBuilder.Entity<Topic>()
            .HasOne(t => t.Module)
            .WithMany(m => m.Topics)
            .HasForeignKey(t => t.ModuleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Student - HomeWork => One-to-Many
        modelBuilder.Entity<HomeWork>()
            .HasOne(h => h.Student)
            .WithMany(s => s.HomeWorks)
            .HasForeignKey(h => h.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
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