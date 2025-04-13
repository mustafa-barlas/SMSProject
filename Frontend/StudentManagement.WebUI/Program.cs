using StudentManagement.WebUI.Services.Student;
using StudentManagement.WebUI.Services.HomeWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// STUDENT SERVICE
builder.Services.AddHttpClient<IStudentService, StudentService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7109"); // STUDENT API URL
});

// HOMEWORK SERVICE
builder.Services.AddHttpClient<IHomeWorkService, HomeWorkService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7109"); // HOMEWORK API URL (aynıysa problem yok)
});
// Module SERVICE


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
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();