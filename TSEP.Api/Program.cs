using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TredjeSemesterEksamensProjekt.SqlServerContext.Migrations.Migrations;
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
using TSEP.Igangsættelse.Application.Projekt.Commands;
using TSEP.Igangsættelse.Application.Projekt.Commands.Implementation;
using TSEP.Igangsættelse.Application.Projekt.Repositories;
using TSEP.Igangsættelse.Infrastructor.Repositories;

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

//Igangsættelse
builder.Services
    .AddScoped<IProjektCreateCommand, ProjektCreateCommand>()
    .AddScoped<IProjektRepository, ProjektRepository>()
    ;


// Database
// Add - Migration RowVersionIgangsættelse - Context TredjeSemesterEksamensProjektContext - Project TSEP.SqlDbContext.Migrations
// Update-Database -Context TredjeSemesterEksamensProjektContext
var connectionString = builder.Configuration.GetConnectionString("TredjeSemesterEksamensProjektDbConnection");
//Set til True under Migration
var updateDatabase = false;
if (updateDatabase) connectionString = "Server=localhost,14330;Database=TredjeSemesterEksamensProjektDomain;user id=test;password=test;MultipleActiveResultSets=true";

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
