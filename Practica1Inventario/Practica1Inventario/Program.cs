using Practica1Inventario.Context;
//using Ocelot.Dependencylnjection;
//using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

AlmacenContext contextoAlmacen = new AlmacenContext();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//OCELOT
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
//builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

contextoAlmacen.Database.EnsureCreated(); // Crear la BD si no existe y verificar que exista

//app.UseOcelot().Wait(); //Espera a que se realize para poder continuar 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
