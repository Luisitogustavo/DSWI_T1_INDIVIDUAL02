using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DSWI_T1_INDIVIDUAL02.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public DateOnly FechaPedido { get; set; }

    public decimal Monto { get; set; }

    public string Estado { get; set; } = null!;

    public int ClienteId { get; set; }

    [ValidateNever]
    public virtual Cliente Cliente { get; set; } = null!;
}
