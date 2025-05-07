using PFT.Application;
using PFT.Infrastructure;
using PFT.Persistence;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using PFT.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Personal Finance Tracker",
        Description = "This is a Web API for 'Personal Finance Tracker' operations",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "Nuwan Indika",
            Email = "nuwan.indika@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/h-g-nuwan-indika-a683ab43/")
        },
        //var TermsOfService = new Uri("#");
        License = new OpenApiLicense()
        {
            Name = "PFT"
        }
    });

    //add JWT Authentication
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Use bearer token to authorize",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"

    });

    option.OperationFilter<AuthResponsesOperationFilter>();
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceService(builder.Configuration);

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

public class OpenApiVersionFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        //swaggerDoc.OpenApi = "3.0.1"; // Explicitly set OpenAPI version
    }
}
