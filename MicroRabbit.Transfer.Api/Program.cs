using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TransferDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDBConnection"));
});

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddTransient<ITransferRepository, TransferRepository>();
builder.Services.AddTransient<TransferDbContext>();
builder.Services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});


#region Plantillas de Configuraci�n CORS

// Configuraci�n CORS: Permitir or�genes, m�todos y encabezados espec�ficos
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.WithOrigins("http://ejemplo.com", "http://otro.com")
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithHeaders("Autorizaci�n", "Content-Type")
);
*/

// Configuraci�n CORS: Permitir cualquier origen, pero m�todos y encabezados espec�ficos
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.AllowAnyOrigin()
        .WithMethods("GET", "POST")
        .WithHeaders("Content-Type")
);
*/

// Configuraci�n CORS: Permitir credenciales y or�genes espec�ficos
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.WithOrigins("http://ejemplo.com")
        .AllowCredentials()
);
*/

// Configuraci�n CORS: Permitir cualquier origen, m�todo y encabezado (no recomendado para producci�n)
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);
*/

// Configuraci�n CORS: Permitir m�ltiples or�genes usando patrones
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
        .WithOrigins("http://*.ejemplo.com", "http://*.otro.com")
        .AllowAnyMethod()
        .AllowAnyHeader()
);
*/

// Configuraci�n CORS: Permitir or�genes espec�ficos, pero con un encabezado expuesto espec�fico
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.WithOrigins("http://ejemplo.com")
        .WithExposedHeaders("Encabezado-Custom")
);
*/

#endregion

var app = builder.Build();

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();