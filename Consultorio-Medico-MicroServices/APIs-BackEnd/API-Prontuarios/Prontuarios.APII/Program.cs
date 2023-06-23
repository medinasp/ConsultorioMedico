using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Prontuarios.Application;
using Prontuarios.Infra.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddApplication();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContextBase>(options => options.UseSqlite(connectionString));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ProntuariosAPI",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Eneias Medina",
            Email = "medinasp@gmail.com",
            Url = new Uri("https://github.com/medinasp")

        }
    });

    var xmlFile = "Prontuarios.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
