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

using TSEP.Igangsættelse.Application.OpgaveType.Commands;
using TSEP.Igangsættelse.Application.OpgaveType.Commands.Implementation;
using TSEP.Igangsættelse.Application.OpgaveType.Repositories;
using TSEP.Igangsættelse.Application.OpgaveType.Query;
using TSEP.Igangsættelse.Application.OpgaveType.Query.Implementation;

using TSEP.Igangsættelse.Infrastructor.Repositories;

using TSEP.Igangsættelse.Application.Projekt.Commands;
using TSEP.Igangsættelse.Application.Projekt.Commands.Implementation;
using TSEP.Igangsættelse.Application.Projekt.Repositories;
using TSEP.Igangsættelse.Application.Projekt.Queries;
using TSEP.Igangsættelse.Application.Projekt.Queries.Implementation;

using TSEP.Kalender.Application.Booking.Commands;
using TSEP.Kalender.Application.Booking.Commands.Implementation;
using TSEP.Kalender.Application.Booking.Query;
using TSEP.Kalender.Application.Booking.Query.Implementation;
using TSEP.Kalender.Application.Booking.Repositories;

using TSEP.Kalender.Infrastructor.Repositories;
using TSEP.Kalender.Infrastructor.DomainServices;

using TSEP.Kalender.Application.Opgave.Repositories;
using TSEP.Kalender.Application.Opgave.Commands;
using TSEP.Kalender.Application.Opgave.Commands.Implementation;
using TSEP.Kalender.Application.Opgave.Query;
using TSEP.Kalender.Application.Opgave.Query.Implementation;

using TSEP.Kalender.Domain.DomainServices;

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
    .AddScoped<IKompetanceGetQuery, KompetanceGetQuery>()
    .AddScoped<IAnsatGetQuery, AnsatGetQuery>()
    .AddScoped<IAnsatGetAllQuery, AnsatGetAllQuery>()
    .AddScoped<IAnsatEditCommand, AnsatEditCommand>()
    .AddScoped<IKompetanceEditCommand, KompetanceEditCommand>()
    ;

//IgangSættelse
builder.Services
    .AddScoped<IOpgaveTypeCreateCommand, OpgaveTypeCreateCommand>()
    .AddScoped<IOpgaveTypeRepository, OpgaveTypeRepository>()
    .AddScoped<IProjektCreateCommand, ProjektCreateCommand>()
    .AddScoped<IProjektRepository, ProjektRepository>()
    .AddScoped<IProjektGetAllQuery, ProjektGetAllQuery>()
    .AddScoped<IProjektGetQuery, ProjektGetQuery>()
    .AddScoped<IProjektEditCommand, ProjektEditCommand>()
    .AddScoped<IOpgaveTypeGetAllQuery, OpgaveTypeGetAllQuery>()
    .AddScoped<IProjektGetAllByKundeQuery, ProjektGetAllByKundeQuery>()
    ;

//Kalender
builder.Services
    //.AddScoped<IBookingCreateCommand, BookingCreateCommand>()
    .AddScoped<IBookingGetAllQuery, BookingGetAllQuery>()
    .AddScoped<IBookingRepository, BookingRepository>()
    .AddScoped<IOpgaveCreateCommand, OpgaveCreateCommand>()
    .AddScoped<IOpgaveGetAllQuery, OpgaveGetAllQuery>()
    .AddScoped<IOpgaveGetQuery, OpgaveGetQuery>()
    .AddScoped<IOpgaveRepository, OpgaveRepository>()
    .AddScoped<IBookingDomainService,BookingDomainService>()
    ;



// Database
// Add -Migration RowVersionIgangsættelse -Context TredjeSemesterEksamensProjektContext -Project TSEP.SqlDbContext.Migrations
// Update-Database -Context TredjeSemesterEksamensProjektContext
var connectionString = builder.Configuration.GetConnectionString("TredjeSemesterEksamensProjektDbConnection");
//Connection string til opdatering af database via migration, Set til True under Migration
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
