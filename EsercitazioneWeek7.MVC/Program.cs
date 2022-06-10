using EsercitazioneWeek7.CORE.BusinessLayer;
using EsercitazioneWeek7.CORE.Interfaces;
using EsercitazioneWeek7.EF;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IBusinessLayer, MainBusinessLayer>();
builder.Services.AddScoped<IRepositoryPiatti, RepositoryPiattiEF>();
builder.Services.AddScoped<IRepositoryMenu, RepositoryMenuEF>();
builder.Services.AddScoped<IRepositoryUtenti, RepositoryUtentiEF>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Login");
        option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Forbidden");
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adm", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("user", policy => policy.RequireRole("User"));
});


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
