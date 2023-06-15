using ApiCatalogo.Repository;
using APICatalogo.Context;
using APICatalogo.Extensions;
using APICatalogo.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Código para evitar erros de referências ciclicas, código 500
builder.Services.AddControllers().AddJsonOptions(opt=> 
            opt.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApiDbContext>(options =>
        options.UseMySql(mySqlConnection, 
        ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("PermitirRequest", 
            builder => 
            builder.WithOrigins("https://apirequest.io/")
                   .WithMethods("GET"));
    }
    );

builder.Services.AddApiVersioning(options => {
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    });

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();

//Cria um novo escopo de serviço separado
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "APICatalago",
        Description = "Catálogo para produtos",
        TermsOfService = new Uri("https://macoratti.net/terms"),
        Contact = new OpenApiContact
        { 
            Name = "Gabriel",
            Email = "gabriel.sousago@gmail.com",
            Url = new Uri("https://macoratti.net"),
        },
        License = new OpenApiLicense
        {
            Name = "Usar para testes",
            Url = new Uri("https://macoratti.net/license"),
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

/*  //Habilitar autenticação no swagger
    var security = new Dictionary<string, IEnumerable<string>>
    {
        {"Bearer", new string[] { }},
    };
    c.AddSecurityDefinition( 
        "Bearer",
        new ApiKeySchema
        {
            In = "header",
            Description = "Copiar 'bearer' + token",
            Name = "Authorizathion",
            Type = "apiKey"
        });
    c.AddSecurityRequirement(security);*/
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Catálogo");
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Catálogo");
        c.InjectStylesheet("/swagger/custom.css");
        c.RoutePrefix = String.Empty;
    });
    app.UseHsts();
}
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseAuthorization();

//app.UseCors(opt => opt.WithOrigins("https://apirequest.io/")
//                        .WithMethods("GET"));

app.UseCors(opt => opt.AllowAnyOrigin());

app.MapControllers();

app.Run();
