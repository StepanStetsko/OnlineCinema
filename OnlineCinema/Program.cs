
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DLL.Context;
using Microsoft.AspNetCore.Identity.UI.Services;
using BLL.Services;
using OnlineCinema;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var identityBuilder = builder.Services.AddDefaultIdentity<User>(options => { 
    options.SignIn.RequireConfirmedAccount = true; 
    options.Password.RequireUppercase = false; 
    options.Password.RequireNonAlphanumeric = false; 
    options.Password.RequireLowercase = false;
}).AddRoles<IdentityRole>();

BLL.Infrastructure.Configuration.ConfigurationService(builder.Services, connectionString, identityBuilder);

builder.Services.AddTransient<IEmailSender, SenGridEmailSender>();

OnlineCinema.Infrastructure.Configuration.ConfigurationService(identityBuilder);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
 