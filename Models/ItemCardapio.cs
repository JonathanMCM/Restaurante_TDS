namespace SistemaGerenciamentoRestaurante.Models
{
    public class ItemCardapio
    {
        public int Id { get; set; }
        public required string? Nome { get; set; }
        public required decimal Preco { get; set; }
        public required string? Categoria { get; set; }
    }
}
