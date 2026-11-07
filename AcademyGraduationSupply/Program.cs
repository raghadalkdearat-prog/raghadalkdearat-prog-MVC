using Microsoft.EntityFrameworkCore;
using AcademyGraduationSupply.Data;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AcademyGraduationPreparationContext>(
    options => options.UseSqlServer(
        "Server=DESKTOP-42O6DLO;Database=AcademyGraduationPreparationDB;Trusted_Connection=True;TrustServerCertificate=True;"
    )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Supply}/{action=About}/{id?}")
    .WithStaticAssets();


app.Run();
