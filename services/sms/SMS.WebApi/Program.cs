using MediatR;
using SMS.Application;
using SMS.Application.Mappings;
using SMS.Persistence;

var builder = WebApplication.CreateBuilder(args);

// CORS tanımı
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebUI", policy =>
    {
        // WebUI'nin çalıştığı portları ekliyoruz
        policy.WithOrigins("https://localhost:7192", "http://localhost:5027") // WebUI portları
            .AllowAnyHeader()   // Herhangi bir header'a izin ver
            .AllowAnyMethod();  // Herhangi bir HTTP metoduna izin ver
    });
});
var configuration = builder.Configuration;

builder.Services.AddPersistenceServices(configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(StudentMappingProfile));

builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>()); // Assembly içindeki MediatR handler'larını kaydediyoruz

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("AllowWebUI");
app.UseAuthorization();

app.MapControllers();

app.Run();