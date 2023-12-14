using Hastane.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Hastane.Utilities;
using Hastane.Repositories.Interfaces;
using Hastane.Repositories.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hastane.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IDbInitializier,DbInitializier>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IDepartmentInfo, DepartmentService>();
builder.Services.AddTransient<IClinicService, ClinicService>();
builder.Services.AddRazorPages();

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
DataSeeding();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Admin}/{controller=Clinics}/{action=Index}/{id?}");

app.Run();
void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializier = scope.ServiceProvider.
            GetRequiredService<IDbInitializier>();
        dbInitializier.Initialize();
    }
}