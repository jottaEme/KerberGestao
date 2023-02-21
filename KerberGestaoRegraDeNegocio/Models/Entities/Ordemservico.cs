using System;
using System.Collections.Generic;

namespace KerberGestaoRegraDeNegocio.Models.Entities;

public partial class Ordemservico
{
    public int IdOrdemServico { get; set; }
    public int IdCliente { get; set; }
    public int IdOrcamento { get; set; }
    public string Titulo { get; set; } = null!;
    public string Detalhamento { get; set; } = null!;
    public int Status { get; set; }
}
