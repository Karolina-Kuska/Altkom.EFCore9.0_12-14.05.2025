using DAL;
using Microsoft.EntityFrameworkCore;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext, MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(MyContext))));

builder.Services.AddScoped<MyService>();

var app = builder.Build();


using (var scope = app.Services.CreateScope()) {
    scope.ServiceProvider.GetRequiredService<MyContext>().Database.EnsureCreated();
}

app.MapGet("/", () => "Hello World!");


using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<MyService>();
}

app.Run();
