using Microsoft.EntityFrameworkCore;
using Bork_Dungeon_Crawler_API.Data;
using Bork_Dungeon_Crawler_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        "Server=(localdb)\\MSSQLLocalDB;Database=BorkDungeonDb;Trusted_Connection=True;"));


// Game services
builder.Services.AddScoped<MonsterService>();
builder.Services.AddScoped<DungeonRoomService>();


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