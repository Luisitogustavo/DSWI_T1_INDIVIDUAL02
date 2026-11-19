
using DSWI_T1_INDIVIDUAL02.Data;
using Microsoft.EntityFrameworkCore;
using DSWI_T1_INDIVIDUAL02.Interfaces;
using DSWI_T1_INDIVIDUAL02.Repositories;
using DSWI_T1_INDIVIDUAL02.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar MVC
builder.Services.AddControllersWithViews();

// Configurar Entity Framework con SQL Server
builder.Services.AddDbContext<EmpresaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmpresaDB")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

var app = builder.Build();

// Configuración HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
