
namespace DSWI_T1_INDIVIDUAL02.Models;

public sealed class DashboardViewModel
{
    public int TotalClientes { get; init; }
    public int TotalPedidos { get; init; }
    public int PedidosPendientes { get; init; }
    public decimal MontoAcumulado { get; init; }
}
