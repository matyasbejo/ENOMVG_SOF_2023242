using ENOMVG_SOF_2023242.Data;
using ENOMVG_SOF_2023242.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SchollingDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SchollingDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ISchoolRepository, SchoolRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
builder.Services.AddDbContext<SchollingDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=school}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=student}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=teacher}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
