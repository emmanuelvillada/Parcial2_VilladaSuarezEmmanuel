using Microsoft.AspNetCore.Identity;
using Parcial3.Dal.Entities;
using Parcial3.Dal;
using Parcial3.Helpers;
using Parcial3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

builder.Services.AddIdentity<User, IdentityRole>(io =>
{
	io.User.RequireUniqueEmail = true; //Valida que el email no esté repetido
	io.Password.RequireDigit = false;
	io.Password.RequiredUniqueChars = 0;
	io.Password.RequireLowercase = false;
	io.Password.RequireNonAlphanumeric = false;
	io.Password.RequireUppercase = false;
	io.Password.RequiredLength = 6;

}).AddEntityFrameworkStores<DatabaseContext>();


builder.Services.AddTransient<SeederDb>();
builder.Services.AddScoped<IUserHelper, UserHelper>();



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
