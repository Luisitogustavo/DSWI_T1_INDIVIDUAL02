
using DSWI_T1_INDIVIDUAL02.Interfaces;
using DSWI_T1_INDIVIDUAL02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSWI_T1_INDIVIDUAL02.Controllers;

public sealed class PedidosController(
    IPedidoService pedidos,
    IClienteService clientes) : Controller
{
    public async Task<IActionResult> Index() =>
        View(await pedidos.ListarAsync());

    [HttpGet]
    public async Task<IActionResult> Crear()
    {
        await CargarClientesAsync();
        return View(new Pedido { FechaPedido = DateOnly.FromDateTime(DateTime.Today) });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Pedido pedido)
    {
        if (!ModelState.IsValid)
        {
            await CargarClientesAsync();
            return View(pedido);
        }

        await pedidos.CrearAsync(pedido);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var pedido = await pedidos.BuscarAsync(id);

        if (pedido is null)
            return NotFound();

        await CargarClientesAsync();
        return View(pedido);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Pedido pedido)
    {
        ModelState.Remove(nameof(Pedido.Cliente));

        if (!ModelState.IsValid)
        {
            await CargarClientesAsync();
            return View(pedido);
        }

        await pedidos.EditarAsync(pedido);
        return RedirectToAction(nameof(Index));
    }


    private async Task CargarClientesAsync()
    {
        ViewBag.Clientes = new SelectList(
            await clientes.ListarAsync(),
            "ClienteId",
            "Nombre");
    }
}
