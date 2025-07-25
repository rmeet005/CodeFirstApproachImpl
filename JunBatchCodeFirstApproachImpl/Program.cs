using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Filter;
using JunBatchCodeFirstApproachImpl.Models;
using JunBatchCodeFirstApproachImpl.Repository;
using JunBatchCodeFirstApproachImpl.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>
    (
        options => options.UseSqlServer
        (
            builder.Configuration.GetConnectionString("dbconn")
        )
    );

builder.Services.AddScoped<IEmpService, EmpService>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<globalexe>();
});

builder.Services.AddAutoMapper(typeof(MapperData));

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
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
