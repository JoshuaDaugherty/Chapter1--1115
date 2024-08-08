using Chapter3finalredone.Models;
using Chapter3finalredone.Models.DataLayer;
using Chapter3finalredone.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection


builder.Services.AddDbContext<LoggingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LoggingCS")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;

}).AddEntityFrameworkStores<LoggingContext>().AddDefaultTokenProviders();


builder.Services.AddRouting(options =>
{
	options.LowercaseUrls = true;
	options.AppendTrailingSlash = true;
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapAreaControllerRoute(
	name: "Admin",
	areaName: "Admin",
	pattern: "Admin/{controller=Home}/{action=Index}/{id?}"


	) ;

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
