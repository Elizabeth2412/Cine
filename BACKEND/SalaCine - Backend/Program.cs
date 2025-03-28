using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.Controllers;
using SalaCine___Backend.Model;
using SalaCine___Backend.Repository;
using SalaCine___Backend.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbCineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionDB"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PeliculaService>();
builder.Services.AddScoped<PeliculaRepository>();
builder.Services.AddScoped<PeliculaController>();
builder.Services.AddScoped<DbCineContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
