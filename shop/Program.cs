using Microsoft.EntityFrameworkCore;
using shop;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<shopcontext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("shopContext") ?? throw new InvalidOperationException("Connection string 'shopContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<shopcontext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddSession();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();
