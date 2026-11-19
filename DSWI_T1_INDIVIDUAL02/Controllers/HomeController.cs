
using System.Diagnostics;
using DSWI_T1_INDIVIDUAL02.Interfaces;
using DSWI_T1_INDIVIDUAL02.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_INDIVIDUAL02.Controllers;

public sealed class HomeController(
    IClienteService clientes,
    IPedidoService pedidos) : Controller
{
    public async Task<IActionResult> Index()
    {
        var listaClientes = (await clientes.ListarAsync()).ToList();
        var listaPedidos = (await pedidos.ListarAsync()).ToList();

        var dashboard = new DashboardViewModel
        {
            TotalClientes = listaClientes.Count,
            TotalPedidos = listaPedidos.Count,
            PedidosPendientes = listaPedidos.Count(p =>
                string.Equals(
                    p.Estado,
                    "Pendiente",
                    StringComparison.OrdinalIgnoreCase)),
            MontoAcumulado = listaPedidos.Sum(p => p.Monto)
        };

        return View(dashboard);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(
        Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel
    {
        RequestId = Activity.Current?.Id
            ?? HttpContext.TraceIdentifier
    });
}
