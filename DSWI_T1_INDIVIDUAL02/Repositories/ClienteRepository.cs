
using DSWI_T1_INDIVIDUAL02.Data;
using DSWI_T1_INDIVIDUAL02.Interfaces;
using DSWI_T1_INDIVIDUAL02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DSWI_T1_INDIVIDUAL02.Repositories;

public sealed class ClienteRepository(EmpresaDbContext context)
    : IClienteRepository
{
    public async Task<IEnumerable<Cliente>> ObtenerTodosAsync() =>
      await context.Clientes
          .FromSqlRaw("EXEC dbo.usp_Clientes_Listar")
          .AsNoTracking()
          .ToListAsync();

    public async Task<Cliente?> ObtenerPorIdAsync(int id) =>
        await context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == id);


    public async Task CrearAsync(Cliente cliente) =>
        await context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Clientes_Crear {cliente.Nombre}, {cliente.CorreoElectronico}");

    public async Task EditarAsync(Cliente cliente) =>
        await context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Clientes_Editar {cliente.ClienteId}, {cliente.Nombre}, {cliente.CorreoElectronico}");

}
