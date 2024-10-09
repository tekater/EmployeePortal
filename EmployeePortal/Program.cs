using EmployeePortal.Models;
using EmployeePortal.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EmployeePortalContextConnection") ?? throw new InvalidOperationException("Connection string 'EmployeePortalContextConnection' not found.");

builder.Services.AddDbContext<EmployeePortalContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EmployeePortalContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=List}/{id?}");

app.Run();
