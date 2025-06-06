using System.Reflection;
using SMS.WebUI.Services.Exam;
using SMS.WebUI.Services.ExamResult;
using SMS.WebUI.Services.HomeWork;
using SMS.WebUI.Services.Module;
using SMS.WebUI.Services.Pdf;
using SMS.WebUI.Services.Student;
using SMS.WebUI.Services.StudentModule;
using SMS.WebUI.Services.Topic;

namespace SMS.WebUI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddScoped<IExamResultPdfService, ExamResultPdfService>();

        
        var baseAddress = configuration.GetValue<string>("ApiBaseUrl") ?? "https://localhost:7109/api/";

        services.AddHttpClient<IStudentService, StudentService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        }); 
        services.AddHttpClient<IExamService, ExamService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IExamResultService, ExamResultService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        
        services.AddHttpClient<IStudentModuleService, StudentModuleService>(client =>
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