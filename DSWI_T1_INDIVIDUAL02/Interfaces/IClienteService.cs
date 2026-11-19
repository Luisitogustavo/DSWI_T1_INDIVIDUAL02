
using DSWI_T1_INDIVIDUAL02.Models;

namespace DSWI_T1_INDIVIDUAL02.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> ListarAsync();
    Task<Cliente?> BuscarAsync(int id);
    Task CrearAsync(Cliente cliente);
    Task EditarAsync(Cliente cliente);
}
