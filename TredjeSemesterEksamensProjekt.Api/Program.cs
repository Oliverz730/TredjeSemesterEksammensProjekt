using Microsoft.EntityFrameworkCore;
using TredjeSemesterEksamensProjekt.SqlDbContextProjekt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Database
// Add-Migration InitialMigration -Context TredjeSemesterEksamensProjektContext -Project TredjeSemesterEksamensProjekt.SqlServerContext.Migrations
// Update-Database -Context TredjeSemesterEksamensProjektContext
var connectionString = builder.Configuration.GetConnectionString("TredjeSemesterEksamensProjektDbConnection");
builder.Services.AddDbContext<TredjeSemesterEksamensProjektContext>(options =>
    options.UseSqlServer(connectionString,
    x => x.MigrationsAssembly("TredjeSemesterEksamensProjekt.SqlServerContext.Migrations"))
    );

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
