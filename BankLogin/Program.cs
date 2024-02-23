using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankLogin.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BankLoginContextConnection") ?? throw new InvalidOperationException("Connection string 'BankLoginContextConnection' not found.");

builder.Services.AddDbContext<BankLoginContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BankLoginUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BankLoginContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
