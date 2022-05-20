using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TechEdu.Models.DataAccess.DataObjects;
using Microsoft.AspNetCore.CookiePolicy;
using TechEdu.Services.Interfaces;
using TechEdu.Services;
using TechEdu.Models.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var connection = builder.Configuration.GetConnectionString("MySqlDefault");
builder.Services.AddDbContext<ColegioContext>(options => options
   .UseMySql(connection, ServerVersion.Parse("5.7.33-mysql"))
);

var settings = builder.Configuration.GetSection("Settings").Get<Settings>();

// Dependency injection
builder.Services.AddScoped<ICryptographyService>(c => new CryptographyService(
                settings.Cryptography.Key,
                settings.Cryptography.InicializationVector)
            );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
