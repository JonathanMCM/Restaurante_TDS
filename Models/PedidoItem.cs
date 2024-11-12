using SistemaGerenciamentoRestaurante.Data;
using SistemaGerenciamentoRestaurante.Services;

namespace SistemaGerenciamentoRestaurante.Models
{
    public class PedidoItem
    {
        public int PedidoId { get; set; }
        public int ItemId { get; set; }
        public required int Quantidade { get; set; }
    }
}
