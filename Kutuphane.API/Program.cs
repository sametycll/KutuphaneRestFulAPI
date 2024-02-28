using Kutuphane.API.Authentication;
using Kutuphane.API.Models.DapperContext;
using Kutuphane.API.Repositories.KategoriRepository;
using Kutuphane.API.Repositories.KitaplarRepository;
using Kutuphane.API.Repositories.UyelerRepository;
using Kutuphane.API.Repositories.YayinEvleriRepository;
using Kutuphane.API.Repositories.YazarlarRepository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IKategoriRepository, KategoriRepository>();
builder.Services.AddTransient<IUyelerRepository, UyelerRepository>();
builder.Services.AddTransient<IYayinEvleriRepository, YayinEvleriRepository>();
builder.Services.AddTransient<IYazarlarRepository, YazarlarRepository>();
builder.Services.AddTransient<IKitaplarRepository, KitaplarRepository>();


builder.Services.AddControllers(x => x.Filters.Add<ApiKeyAuthFilter>());
//builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "The API Key to access the API",
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        {scheme, new List<string> () }
    };
    c.AddSecurityRequirement(requirement);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
