using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//this for the SLUG
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls= true;
    options.AppendTrailingSlash= true;
});

builder.Services.AddDbContext<ContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext"))
);

//want to define builder above before calling build
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}"); //added optional slug as per documentation

app.Run();
