
using DSWI_T1_INDIVIDUAL02.Interfaces;
using DSWI_T1_INDIVIDUAL02.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_INDIVIDUAL02.Controllers;

public sealed class ClientesController(IClienteService service) : Controller
{
    public async Task<IActionResult> Index() =>
        View(await service.ListarAsync());

    [HttpGet]
    public IActionResult Crear() => View(new Cliente());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Cliente cliente)
    {
        if (!ModelState.IsValid)
            return View(cliente);

        await service.CrearAsync(cliente);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var cliente = await service.BuscarAsync(id);
        return cliente is null ? NotFound() : View(cliente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Cliente cliente)
    {
        if (!ModelState.IsValid)
            return View(cliente);

        await service.EditarAsync(cliente);
        return RedirectToAction(nameof(Index));
    }
}
