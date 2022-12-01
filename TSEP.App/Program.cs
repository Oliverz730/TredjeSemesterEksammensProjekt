using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TredjeSemesterEksammensProjekt.Data;
using TSEP.App.Infrastructure.Contract;
using TSEP.App.Infrastructure.Implementation;
using TSEP.UserDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("WebAppUserDbContextConnection");
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString,
    x=> x.MigrationsAssembly("TSEP.UserDbMigration"))
    );


builder.Configuration.AddEnvironmentVariables();

// Database
// Add-Migration NonLocal -Context WebAppUserDbContext -Project TSEP.UserDbMigration
// Update-Database -Context WebAppUserDbContext


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<WebAppUserDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Add Claims
builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("TeknikerPolicy", policyBuilder => policyBuilder.RequireAssertion(context => context.User.HasClaim(c => c.Type == "Tekniker" || c.Type == "Admin")));
    options.AddPolicy("SælgerPolicy", policyBuilder => policyBuilder.RequireAssertion(context => context.User.HasClaim(c => c.Type == "Sælger" || c.Type == "Admin")));
    options.AddPolicy("KonverterPolicy", policyBuilder => policyBuilder.RequireAssertion(context => context.User.HasClaim(c => c.Type == "Konverter" || c.Type == "Admin")));
    options.AddPolicy("KonsulentPolicy", policyBuilder => policyBuilder.RequireAssertion(context => context.User.HasClaim(c => c.Type == "Konsulent" || c.Type == "Admin")));

    options.AddPolicy("AdminPolicy", policyBuilder => policyBuilder.RequireClaim("Admin"));
}
);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Tekniker", "TeknikerPolicy");
    options.Conventions.AuthorizeFolder("/Sælger", "SælgerPolicy");
    options.Conventions.AuthorizeFolder("/Konverter", "KonverterPolicy");
    options.Conventions.AuthorizeFolder("/Konsulent", "KonsulentPolicy");
});

//IOC

builder.Services.AddHttpClient<IStamDataService, StamDataService>(client => 
    client.BaseAddress = new Uri(builder.Configuration["StamDataBaseUrl"])
);

builder.Services.AddHttpClient<IIgangsættelseService, IgangsættelseService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["StamDataBaseUrl"])
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
