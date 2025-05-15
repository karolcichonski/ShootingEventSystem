using Microsoft.AspNetCore.Identity;
using ShootingEventSystemWebAPI;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Services;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TournamentDbContext>();
builder.Services.AddScoped<Seeder>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IArbiterService, ArbiterService>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<ICompetitionService, CompetitionService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
seeder.Seed();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShootingEventSystem API V1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
