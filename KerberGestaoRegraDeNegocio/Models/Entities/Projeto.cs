using System;
using System.Collections.Generic;

namespace KerberGestaoRegraDeNegocio.Models.Entities
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; } = null!;
        public int StatusProjeto { get; set; }
    }
}
