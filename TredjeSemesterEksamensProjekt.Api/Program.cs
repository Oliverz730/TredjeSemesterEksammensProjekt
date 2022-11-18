using Microsoft.EntityFrameworkCore;
using TredjeSemesterEksamensProjekt.Opgave.Infrastructor.Repositories;
using TredjeSemesterEksamensProjekt.SqlDbContextProjekt;
using TredjeSemesterEksamensProjekt.StamData.Application.Commands;
using TredjeSemesterEksamensProjekt.StamData.Application.Commands.Implementation;
using TredjeSemesterEksamensProjekt.StamData.Application.Queries;
using TredjeSemesterEksamensProjekt.StamData.Application.Queries.Implementation;
using TredjeSemesterEksamensProjekt.StamData.Application.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IOC

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
//String 1 :
//"TredjeSemesterEksamensProjektDbConnection": "Server=localhost;Database=TredjeSemesterEksamensProjektDomain;Trusted_Connection=True;MultipleActiveResultSets=true"
//String 2 :
//"TredjeSemesterEksamensProjektDbConnection": "Server=LAPTOP-1HT927JP;Database=TredjeSemesterEksamensProjektDomain;Trusted_Connection=True;MultipleActiveResultSets=true"
var connectionString = builder.Configuration.GetConnectionString("TredjeSemesterEksamensProjektDbConnection");
builder.Services.AddDbContext<TredjeSemesterEksamensProjektContext>(options =>
    options.UseSqlServer(connectionString,
    x => x.MigrationsAssembly("TredjeSemesterEksamensProjekt.SqlServerContext.Migrations"))
    );


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
