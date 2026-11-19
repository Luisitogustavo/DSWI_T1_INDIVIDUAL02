
using DSWI_T1_INDIVIDUAL02.Interfaces;
using DSWI_T1_INDIVIDUAL02.Models;

namespace DSWI_T1_INDIVIDUAL02.Services;

public sealed class PedidoService(IPedidoRepository repository)
    : IPedidoService
{
    public Task<IEnumerable<Pedido>> ListarAsync() =>
        repository.ObtenerTodosAsync();

    public Task<Pedido?> BuscarAsync(int id) =>
        repository.ObtenerPorIdAsync(id);

    public Task CrearAsync(Pedido pedido) =>
        repository.CrearAsync(pedido);

    public Task EditarAsync(Pedido pedido) =>
        repository.EditarAsync(pedido);
}
