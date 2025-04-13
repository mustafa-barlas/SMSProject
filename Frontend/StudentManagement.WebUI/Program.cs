using StudentManagement.WebUI.Services.Student;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IStudentService, StudentService>();
// HomeWorks API için örnek bir HttpClient kaydı ekleyeceksek:
builder.Services.AddHttpClient<IStudentService, StudentService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7109"); // API URL'si
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();