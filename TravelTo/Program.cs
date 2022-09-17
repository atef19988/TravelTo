using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;
using TravelTo.Ef;
using TravelTo.Ef.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TrvelToDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")

    /*   ,b => b.MigrationsAssembly(typeof(TrvelToDbContext).Assembly.FullName)*/
    ));

builder.Services.AddScoped<IRepository<TbTour>, BaseRepository<TbTour>>();
builder.Services.AddScoped<IRepository<TbCheckoutTourUser>, BaseRepository<TbCheckoutTourUser>>();
builder.Services.AddScoped<IRepository<TbCompetition>, BaseRepository<TbCompetition>>();  
builder.Services.AddScoped<IRepository<TbCompetitionUser>, BaseRepository<TbCompetitionUser>>();
builder.Services.AddScoped<IRepository<TbLocationTour>, BaseRepository<TbLocationTour>>();
builder.Services.AddScoped<IRepository<TbSettings>, BaseRepository<TbSettings>>();
builder.Services.AddScoped<IRepository<TbSlider>, BaseRepository<TbSlider>>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 10;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase=false;
    option.Password.RequireDigit = false;
    option.User.RequireUniqueEmail = true;
    
}).AddEntityFrameworkStores<TrvelToDbContext>();

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
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"); 

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"); 

});


app.Run();
