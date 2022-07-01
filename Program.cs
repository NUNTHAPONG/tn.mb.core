using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<SalesDbContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("pg"))
        .UseSnakeCaseNamingConvention();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
                       builder =>
                       {
                           builder.WithOrigins("http://localhost:4200")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                       });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empty}/{action=Index}/{id?}");
});
app.MapControllers();
app.UseCors("AllowOrigin");
app.Run();
