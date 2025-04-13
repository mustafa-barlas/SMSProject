using StudentManagement.WebUI.Services.HomeWork;
using StudentManagement.WebUI.Services.Module;
using StudentManagement.WebUI.Services.Student;
using StudentManagement.WebUI.Services.Topic;

namespace StudentManagement.WebUI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        var baseAddress = configuration.GetValue<string>("ApiBaseUrl") ?? "https://localhost:7109";

        services.AddHttpClient<IStudentService, StudentService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });

        services.AddHttpClient<IHomeWorkService, HomeWorkService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });

        services.AddHttpClient<IModuleService, ModuleService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });

        services.AddHttpClient<ITopicService, TopicService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });

        return services;
    }
}