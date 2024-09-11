using Microsoft.EntityFrameworkCore;
using TechnologyKida.Repository;
using TechnologyKida.Repository.Implementations;
using TechnologyKida.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("TechnologyKida.UI"))
);
//DI :  Tightly coupled ---convert--- loosly coupled
//DI : Achieve IOC
//AddSingleton,AddScoped,AddTransient

builder.Services.AddScoped<ICountryRepo,CountryRepo>();
builder.Services.AddScoped<IStateRepo,StateRepo>();
builder.Services.AddScoped<ICityRepo,CityRepo>();
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
});


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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
