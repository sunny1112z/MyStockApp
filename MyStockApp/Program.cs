using Microsoft.EntityFrameworkCore;
using MyStockApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyStockContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyStockDB")));

builder.Services.AddScoped<MyStockContext>(); 
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
