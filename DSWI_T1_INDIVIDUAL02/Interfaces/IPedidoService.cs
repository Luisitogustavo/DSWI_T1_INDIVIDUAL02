
using DSWI_T1_INDIVIDUAL02.Models;

namespace DSWI_T1_INDIVIDUAL02.Interfaces;

public interface IPedidoService
{
    Task<IEnumerable<Pedido>> ListarAsync();
    Task<Pedido?> BuscarAsync(int id);
    Task CrearAsync(Pedido pedido);
    Task EditarAsync(Pedido pedido);
}
