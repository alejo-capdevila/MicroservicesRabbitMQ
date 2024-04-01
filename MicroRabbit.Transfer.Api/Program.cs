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


#region Plantillas de Configuración CORS

// Configuración CORS: Permitir orígenes, métodos y encabezados específicos
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.WithOrigins("http://ejemplo.com", "http://otro.com")
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithHeaders("Autorización", "Content-Type")
);
*/

// Configuración CORS: Permitir cualquier origen, pero métodos y encabezados específicos
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.AllowAnyOrigin()
        .WithMethods("GET", "POST")
        .WithHeaders("Content-Type")
);
*/

// Configuración CORS: Permitir credenciales y orígenes específicos
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.WithOrigins("http://ejemplo.com")
        .AllowCredentials()
);
*/

// Configuración CORS: Permitir cualquier origen, método y encabezado (no recomendado para producción)
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);
*/

// Configuración CORS: Permitir múltiples orígenes usando patrones
/*
options.AddPolicy("PoliticaCORS", builder =>
    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
        .WithOrigins("http://*.ejemplo.com", "http://*.otro.com")
        .AllowAnyMethod()
        .AllowAnyHeader()
);
*/

// Configuración CORS: Permitir orígenes específicos, pero con un encabezado expuesto específico
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