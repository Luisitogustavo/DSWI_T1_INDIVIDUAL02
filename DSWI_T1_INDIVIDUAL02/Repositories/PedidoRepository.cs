
using DSWI_T1_INDIVIDUAL02.Data;
using DSWI_T1_INDIVIDUAL02.Interfaces;
using DSWI_T1_INDIVIDUAL02.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_INDIVIDUAL02.Repositories;

public sealed class PedidoRepository(EmpresaDbContext context)
    : IPedidoRepository
{

    public async Task<IEnumerable<Pedido>> ObtenerTodosAsync() =>
        await context.Pedidos
            .FromSqlRaw("EXEC dbo.usp_Pedidos_Listar")
            .AsNoTracking()
            .ToListAsync();


    public async Task<Pedido?> ObtenerPorIdAsync(int id) =>
        await context.Pedidos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PedidoId == id);

    public async Task CrearAsync(Pedido pedido) =>
        await context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Pedidos_Crear {pedido.FechaPedido}, {pedido.Monto}, {pedido.Estado}, {pedido.ClienteId}");

    public async Task EditarAsync(Pedido pedido) =>
        await context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.usp_Pedidos_Editar {pedido.PedidoId}, {pedido.FechaPedido}, {pedido.Monto}, {pedido.Estado}, {pedido.ClienteId}");

}
