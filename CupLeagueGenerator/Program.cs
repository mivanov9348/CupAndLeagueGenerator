using CupLeagueGenerator.Core.Services.Cup;
using CupLeagueGenerator.Core.Services.Fixture;
using CupLeagueGenerator.Core.Services.League;
using CupLeagueGenerator.Core.Services.Participant;
using CupLeagueGenerator.Data;
using CupLeagueGenerator.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CupLeagueDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<ICupService, CupService>();
builder.Services.AddScoped<ILeagueService, LeagueService>();
builder.Services.AddScoped<IFixtureService, FixtureService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();

builder.Services.AddDefaultIdentity<ApplicationUser>(o =>
{
    o.SignIn.RequireConfirmedAccount = false;
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<CupLeagueDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Menu}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
