
using DSWI_T1_INDIVIDUAL02.Models;

namespace DSWI_T1_INDIVIDUAL02.Interfaces;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> ObtenerTodosAsync();
    Task<Pedido?> ObtenerPorIdAsync(int id);
    Task CrearAsync(Pedido pedido);
    Task EditarAsync(Pedido pedido);
}
