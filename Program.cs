using Agedamento.Data;
using Agendamento.Repositorio;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BancoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
   
});

builder.Services.AddScoped<ITipoExamesRepositorio, TipoExamesRepositorio>();
builder.Services.AddScoped<IPacientesRepositorio, PacientesRepositorio>();
builder.Services.AddScoped<IExameRepositorio, ExameRepositorio>();
builder.Services.AddScoped<IConsultaRepositorio , ConsultaRepositorio>();






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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
