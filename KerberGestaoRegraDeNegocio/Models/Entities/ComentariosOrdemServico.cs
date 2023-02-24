namespace KerberGestaoRegraDeNegocio.Models.Entities
{
    public class ComentariosOrdemServico
    {
        public int Id { get; set; }
        public int IdOrdemServico { get; set; }
        public string Comentario { get; set; }
    }
}
