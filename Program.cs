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
builder.Services.AddDbContext<CleanDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("pg"));
}, ServiceLifetime.Scoped);
builder.Services.AddCors(options =>
{
    options.AddPolicy("TnPolicy",
                       builder =>
                       {
                           builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                       });
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empty}/{action=Index}/{id}");
});
app.MapControllers();
app.UseCors("TnPolicy");
app.Run();
