using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Persistence.Context;

namespace SMS.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext'i kaydediyoruz
        services.AddDbContext<SMSAPIDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"))); // ConnectionString'inizi buraya ekleyin

        
        
        // Tüm Repositories otomatik taranıp, interface ile eşleşenler scoped olarak eklenir
        services.Scan(scan => scan
            .FromAssemblies(
                Assembly.GetExecutingAssembly() // SMS.Persistence
            )
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        
        // // Diğer servisler
        // services.AddScoped<IStudentReadRepository, StudentReadRepository>();
        // services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
        //
        // services.AddScoped<IModuleReadRepository, ModuleReadRepository>();
        // services.AddScoped<IModuleWriteRepository, ModuleWriteRepository>();
        //
        // services.AddScoped<IHomeWorkReadRepository, HomeWorkReadRepository>();
        // services.AddScoped<IHomeWorkWriteRepository, HomeWorkWriteRepository>();
        //
        //
        // services.AddScoped<ITopicReadRepository, TopicReadRepository>();
        // services.AddScoped<ITopicWriteRepository, TopicWriteRepository>();
        //
        // services.AddScoped<IStudentModuleWriteRepository, StudentModuleWriteRepository>();
        // services.AddScoped<IStudentModuleReadRepository, StudentModuleReadRepository>();
    }
}