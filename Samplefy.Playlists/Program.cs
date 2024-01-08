using MongoDB.Driver;
using Samplefy.Playlists.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoConnectionString = builder.Configuration.GetConnectionString("Mongo");
builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoConnectionString));

builder.Services.AddScoped<IMongoDatabase>(x =>
{
    var mongoClient = x.GetRequiredService<IMongoClient>();
    return mongoClient.GetDatabase("samplefy");
});

builder.Services.AddScoped<IMongoCollection<Playlist>>(s =>
{
    var database = s.GetRequiredService<IMongoDatabase>();
    return database.GetCollection<Playlist>("playlists");
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();