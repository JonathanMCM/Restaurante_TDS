using SistemaGerenciamentoRestaurante.Data;
using SistemaGerenciamentoRestaurante.Models;
using System;
using System.Linq;

namespace SistemaGerenciamentoRestaurante.Services
{
    public class PedidoService
    {
        private readonly RestauranteDbContext _context;

        public PedidoService(RestauranteDbContext context)
        {
            _context = context;
        }

        public Pedido CriarPedido(int mesaId, List<PedidoItem> itens)
        {
            var pedido = new Pedido
            {
                MesaId = mesaId,
                Status = "Em Preparação",
                Data = DateTime.Now, // Definindo a data do pedido
                Total = itens.Sum(i =>
                {
                    var itemCardapio = _context.ItensCardapio.Find(i.ItemId);
                    if (itemCardapio == null)
                    {
                        throw new Exception($"Item com ID {i.ItemId} não encontrado.");
                    }
                    return i.Quantidade * itemCardapio.Preco;
                }),
                PedidoItens = itens
            };

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return pedido; // Retornando o pedido criado para o controlador
        }

        public decimal GerarRelatorioVendas(DateTime data)
        {
            var totalVendas = _context.Pedidos
                .Where(p => p.Status != "Cancelado" && p.Data.Date == data.Date)
                .Sum(p => p.Total);
            return totalVendas;
        }
    }
}