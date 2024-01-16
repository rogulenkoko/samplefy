using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Samplefy.Core.Repositories;
using Samplefy.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
    new DefaultAzureCredential());

// Add services to the container.

builder.Services.AddControllers();

var pgConnectionString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContextPool<ApplicationDbContext>(o => 
    o.UseNpgsql(pgConnectionString)
    .UseSnakeCaseNamingConvention());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDeveloperExceptionPage();

app.Run();
