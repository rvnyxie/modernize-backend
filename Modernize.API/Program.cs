using Microsoft.AspNetCore.Identity;
using Modernize.API;
using Modernize.Application;
using Modernize.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Application services
builder.Services.AddApplication();

// Register Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration);

// ASPNETCORE Identity, Register services
builder.Services.AddAuthorization();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultUI();

var app = builder.Build();

// ASPNETCORE Identity, map Identity endpoints
app.MapIdentityApi<ApplicationUser>();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DataSeeder.Initialize(services);
}

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
