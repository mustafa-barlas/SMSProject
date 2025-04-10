using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Application.Repositories.StudentRepository;
using SMS.Persistence.Context;
using SMS.Persistence.Repositories.StudentRepository;

namespace SMS.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext'i kaydediyoruz
        services.AddDbContext<SMSAPIDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); // ConnectionString'inizi buraya ekleyin
        
        // Diğer servisler
        services.AddScoped<IStudentReadRepository, StudentReadRepository>();
        services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
    }
}