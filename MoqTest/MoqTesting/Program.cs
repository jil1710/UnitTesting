using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoqTesting.Data;
using MoqTesting.Repository;
using MoqTesting.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MoqContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoqContext") ?? throw new InvalidOperationException("Connection string 'MoqContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmployeeManagement,EmployeeManagement>();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();
