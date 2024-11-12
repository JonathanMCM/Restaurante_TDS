namespace SistemaGerenciamentoRestaurante.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public List<PedidoItem> PedidoItens { get; set; }
        
        // Propriedades adicionais
        public int MesaId { get; set; } // Representa a mesa associada ao pedido
        public decimal Total { get; set; } // Valor total do pedido
        public DateTime Data { get; set; } // Data do pedido

        // Construtor sem parâmetros (padrão)
        public Pedido()
        {
            Status = "Pendente"; // Atribuindo um valor padrão
            PedidoItens = new List<PedidoItem>(); // Inicializando a lista
            MesaId = 0; // Inicializando com valor padrão (se necessário, pode ser validado depois)
            Total = 0.0m; // Inicializando com valor padrão
            Data = DateTime.Now; // Inicializando com a data e hora atuais
        }

        // Construtor com parâmetros
        public Pedido(int id, string status, int mesaId, decimal total, DateTime data, List<PedidoItem> pedidoItens = null)
        {
            Id = id;
            Status = status;
            MesaId = mesaId;
            Total = total;
            Data = data;
            PedidoItens = pedidoItens ?? new List<PedidoItem>(); // Caso a lista não seja passada, inicializa com uma lista vazia
        }

        // Método para validar dados antes de salvar (opcional)
        public void ValidarPedido()
        {
            if (MesaId <= 0)
                throw new Exception("Mesa ID inválido.");
            if (Total < 0)
                throw new Exception("Total do pedido não pode ser negativo.");
        }
    }
}