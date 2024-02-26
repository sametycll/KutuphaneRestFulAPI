using Kutuphane.API.Models.DapperContext;
using Kutuphane.API.Repositories.KategoriRepository;
using Kutuphane.API.Repositories.UyelerRepository;
using Kutuphane.API.Repositories.YayinEvleriRepository;
using Kutuphane.API.Repositories.YazarlarRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IKategoriRepository, KategoriRepository>();
builder.Services.AddTransient<IUyelerRepository, UyelerRepository>();
builder.Services.AddTransient<IYayinEvleriRepository,YayinEvleriRepository>();
builder.Services.AddTransient<IYazarlarRepository,YazarlarRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
