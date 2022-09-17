using Microsoft.OpenApi.Models;
using Salud_Amigos.Api;
using System.Reflection;
using System.Xml.XPath;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddConfiguration();
builder.Services.AddSwaggerGen(c=>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Salud Amigos",
                Version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "local"
            }
        );
      
        var xmlCommentStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Salud_Amigos.Api.Api.xml");
        if (xmlCommentStream is not null)
        {
            c.IncludeXmlComments(() => new XPathDocument(xmlCommentStream), true);
        }
    });
builder.Services.AddProjectDependencies();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "api v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

