using BaseCoffee.BLL.Managers.Abstract;
using BaseCoffee.BLL.Managers.Concrete;
using BaseCoffee.DAL;
using BaseCoffee.DAL.Context;
using BaseCoffee.DAL.Entities.Concrete;
using BaseCoffee.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDalService();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole<string>>()
    .AddEntityFrameworkStores<MyDbContext>();

builder.Services.AddAuthorization(options => { options.AddPolicy("Customer", policy => policy.RequireRole("Customer")); options.AddPolicy("Admin", policy => policy.RequireRole("Admin")); });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IGenericManager<,>), typeof(GenericManager<,>));
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
app.MapRazorPages();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(

      name: "areas",

      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
