using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Application.Repositories.HomeWorkRepository;
using SMS.Application.Repositories.ModuleRepository;
using SMS.Application.Repositories.StudentRepository;
using SMS.Application.Repositories.TopicRepository;
using SMS.Persistence.Context;
using SMS.Persistence.Repositories.HomeWrokRepository;
using SMS.Persistence.Repositories.ModuleRepository;
using SMS.Persistence.Repositories.StudentRepository;
using SMS.Persistence.Repositories.TopicRepository;

namespace SMS.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext'i kaydediyoruz
        services.AddDbContext<SMSAPIDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"))); // ConnectionString'inizi buraya ekleyin

        // Diğer servisler
        services.AddScoped<IStudentReadRepository, StudentReadRepository>();
        services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();

        services.AddScoped<IModuleReadRepository, ModuleReadRepository>();
        services.AddScoped<IModuleWriteRepository, ModuleWriteRepository>();

        services.AddScoped<IHomeWorkReadRepository, HomeWorkReadRepository>();
        services.AddScoped<IHomeWorkWriteRepository, HomeWorkWriteRepository>();


        services.AddScoped<ITopicReadRepository, TopicReadRepository>();
        services.AddScoped<ITopicWriteRepository, TopicWriteRepository>();
    }
}