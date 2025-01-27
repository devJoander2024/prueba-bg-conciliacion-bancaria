using Microsoft.EntityFrameworkCore;
using WebAPI_Walther_Olivo.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()  // Permite solicitudes desde cualquier origen
              .AllowAnyHeader()  // Permite cualquier encabezado
              .AllowAnyMethod(); // Permite cualquier mtodo HTTP (GET, POST, PUT, DELETE, etc.)
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(); // Aqu habilitas CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
