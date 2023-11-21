using ExamenB.Context;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

SistemaMedicoContext contextSistema = new SistemaMedicoContext();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true); //Configuracion ocelot
builder.Services.AddOcelot(); //Agregar ocelot a servicios

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

contextSistema.Database.EnsureCreated(); //Verificar que exista la BD y si no crearla

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseOcelot().Wait(); //App usa ocelot como peticion asíncrona