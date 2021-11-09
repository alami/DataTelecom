using System;
using Data.Web;
using Data.Web.Services;
using Data.Web.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddHttpClient<IProductService, ProductService>();
SD.ProductAPIBase = configuration.GetValue<string>("ServiceUrls:ProductAPI");
SD.ShoppingCartAPIBase = configuration.GetValue<string>("ServiceUrls:ShoppingCartAPI");

builder.Services.AddScoped<IProductService, ProductService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options => {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie("Cookies", c=>c.ExpireTimeSpan=TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options => 
    {
        options.Authority = configuration.GetValue<string>("ServiceUrls:IdentityAPI");
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "data";
        options.ClientSecret = "secret";
        options.ResponseType = "code";

        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("data");
        options.SaveTokens = true;

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
