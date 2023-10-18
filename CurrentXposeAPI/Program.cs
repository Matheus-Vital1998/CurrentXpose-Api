using CurrentXposeAPI.Context;
using CurrentXposeAPI.Repository;
using CurrentXposeAPI.Repository.Interfaces;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CurrentXposeAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CurrentXpose"),
    builder => builder.MigrationsAssembly(typeof(CurrentXposeAPIContext).Assembly.FullName)));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IMoradorService, MoradorService>();

// Add repositorys
builder.Services.AddScoped<IMoradorRepository, MoradorRepository>();
builder.Services.AddScoped<ICondominioRepository, CondominioRepository>();
builder.Services.AddScoped<ILeituraRepository, LeituraRepository>();
builder.Services.AddScoped<IPredioRepository, PredioRepository>();
builder.Services.AddScoped<IResidenciaRepository, ResidenciaRepository>();
builder.Services.AddScoped<ISindicoRepository, SindicoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
