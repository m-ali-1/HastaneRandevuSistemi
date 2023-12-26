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
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IDbInitializier, DbInitializier>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IDepartmentInfo, DepartmentService>();
builder.Services.AddTransient<IClinicService, ClinicService>();
builder.Services.AddTransient<ITimingService, TimingService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();

builder.Services.AddMvc().AddRazorOptions(options =>
{
    options.ViewLocationFormats.Add("/Areas/Admin/Views/{1}/{0}.cshtml");
    options.ViewLocationFormats.Add("/Areas/Admin/Views/Shared/{0}.cshtml");
    options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
    options.ViewLocationFormats.Add("/Pages/Shared/{0}.cshtml");
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
DataSeeding();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
/*app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Admin}/{controller=Departments}/{action=Index}/{id?}");*/
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});


app.Run();

void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializier>();
        dbInitializer.Initialize();
    }
}