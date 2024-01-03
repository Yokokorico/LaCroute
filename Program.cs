
using LaCroute.Data;
using LaCroute.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<FooterDataFilter>();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.AddService<FooterDataFilter>(); 
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LaCrouteContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("LaCrouteContext")
?? throw new InvalidOperationException("Connection string 'LaCrouteContext' not found.")));


var app = builder.Build();
// context.Database.Migrate();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
