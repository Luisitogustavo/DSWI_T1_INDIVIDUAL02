
using DSWI_T1_INDIVIDUAL02.Interfaces;
using DSWI_T1_INDIVIDUAL02.Models;

namespace DSWI_T1_INDIVIDUAL02.Services;

public sealed class ClienteService(IClienteRepository repository)
    : IClienteService
{
    public Task<IEnumerable<Cliente>> ListarAsync() =>
        repository.ObtenerTodosAsync();

    public Task<Cliente?> BuscarAsync(int id) =>
        repository.ObtenerPorIdAsync(id);

    public Task CrearAsync(Cliente cliente) =>
        repository.CrearAsync(cliente);

    public Task EditarAsync(Cliente cliente) =>
        repository.EditarAsync(cliente);
}
