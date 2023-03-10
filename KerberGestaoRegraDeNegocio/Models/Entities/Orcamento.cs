using System;
using System.Collections.Generic;
using KerberGestaoRegraDeNegocio.Models.Enums;

namespace KerberGestaoRegraDeNegocio.Models.Entities
{
    public partial class Orcamento
    {
        public int IdOrcamentos { get; set; }
        public string NomeOrcamento { get; set; } = null!;
        public StatusOrcamentoEnum StatusOrcamento { get; set; }
    }
}
