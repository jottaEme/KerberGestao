using System;
using System.Collections.Generic;
using KerberGestaoRegraDeNegocio.Models.Enums;

namespace KerberGestaoRegraDeNegocio.Models.Entities
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; } = null!;
        public string CpfCliente { get; set; }
        public string EnderecoCliente { get; set; } = null!;
        public string? BairroCliente { get; set; }
        public string CidadeCliente { get; set; } = null!;
        public string EstadoCliente { get; set; } = null!;
        public string? TelefoneCliente { get; set; }
        public string? CelularCliente { get; set; }
        public StatusClienteEnum Status { get; set; }
    }
}
