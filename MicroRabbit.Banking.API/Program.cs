using MediatR;
using MicroRabbit.BakingApplication.Interfaces;
using MicroRabbit.BakingApplication.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BankingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDBConnection"));
});

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<BankingDbContext>();
builder.Services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});


#region Plantillas de Configuración CORS
/*
// Configuración CORS: Permitir orígenes, métodos y encabezados específicos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com", "http://otro.com")
//        .WithMethods("GET", "POST", "PUT", "DELETE")
//        .WithHeaders("Autorización", "Content-Type")
//);


// Configuración CORS: Permitir cualquier origen, pero métodos y encabezados específicos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.AllowAnyOrigin()
//        .WithMethods("GET", "POST")
//        .WithHeaders("Content-Type")
//);


// Configuración CORS: Permitir credenciales y orígenes específicos

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com")
//        .AllowCredentials()
//);


// Configuración CORS: Permitir cualquier origen, método y encabezado (no recomendado para producción)

//options.AddPolicy("CorsPolicy", builder =>
//    builder.AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//);


// Configuración CORS: Permitir múltiples orígenes usando patrones

//options.AddPolicy("CorsPolicy", builder =>
//    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
//        .WithOrigins("http://*.ejemplo.com", "http://*.otro.com")
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//);


// Configuración CORS: Permitir orígenes específicos, pero con un encabezado expuesto específico

//options.AddPolicy("CorsPolicy", builder =>
//    builder.WithOrigins("http://ejemplo.com")
//        .WithExposedHeaders("Encabezado-Custom")
//);
*/

#endregion


var app = builder.Build();

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
