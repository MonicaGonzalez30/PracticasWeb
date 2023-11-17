using Practica1Inventario.Context;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

AlmacenContext contextoAlmacen = new AlmacenContext();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true); // Configuracion del ocelot
builder.Services.AddOcelot(); // Se agrega ocelot a los servicios

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

contextoAlmacen.Database.EnsureCreated(); // Crear la BD si no existe y verificar que exista

app.UseOcelot().Wait(); // Se agrega para que la aplicacion use ocelot
                        // es una peticion asíncrona y espera a que se realice para poder continuar

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
