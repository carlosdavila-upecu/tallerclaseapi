using AccessoData.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Negocio.Repositorio;
using Negocio.Repositorio.IRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taller API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please Bearer and then token in the field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
});

builder.Services.AddDbContext<AppDbContext>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Repositorios
builder.Services.AddScoped<ILlamadaRepositorio, LlamadaRepositorio>();

var app = builder.Build();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
