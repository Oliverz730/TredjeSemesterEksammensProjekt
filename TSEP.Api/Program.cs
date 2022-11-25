using Microsoft.EntityFrameworkCore;
using TSEP.SqlDbContext;
using TSEP.StamData.Application.Ansat.Commands;
using TSEP.StamData.Application.Ansat.Commands.Implementation;
using TSEP.StamData.Application.Ansat.Queries;
using TSEP.StamData.Application.Ansat.Queries.Implementation;
using TSEP.StamData.Application.Ansat.Repositories;
using TSEP.StamData.Application.Kompetance.Commands;
using TSEP.StamData.Application.Kompetance.Commands.Implementation;
using TSEP.StamData.Application.Kompetance.Queries;
using TSEP.StamData.Application.Kompetance.Queries.Implementation;
using TSEP.StamData.Application.Kompetance.Repositories;
using TSEP.StamData.Infrastructor.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Docker
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IOC

//StamData
builder.Services
    .AddScoped<IKompetanceCreateCommand, KompetanceCreateCommand>()
    .AddScoped<IKompetanceRepository, KompetanceRepository>()
    .AddScoped<IAnsatRepository, AnsatRepository>()
    .AddScoped<IAnsatCreateCommand, AnsatCreateCommand>()
    .AddScoped<IKompetanceGetAllQuery, KompetanceGetAllQuery>()
    .AddScoped<IKompetanceGetQuery,KompetanceGetQuery>()
    .AddScoped<IAnsatGetQuery, AnsatGetQuery>()
    .AddScoped<IAnsatEditCommand, AnsatEditCommand>()
    ;


// Database
// Add-Migration InitialMigration -Context TredjeSemesterEksamensProjektContext -Project TredjeSemesterEksamensProjekt.SqlServerContext.Migrations
// Update-Database -Context TredjeSemesterEksamensProjektContext
var connectionString = builder.Configuration.GetConnectionString("TredjeSemesterEksamensProjektDbConnection");


builder.Services.AddDbContext<TredjeSemesterEksamensProjektContext>(options =>
    options.UseSqlServer(connectionString,
    x => x.MigrationsAssembly("TSEP.SqlDbContext.Migrations"))
    );


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
