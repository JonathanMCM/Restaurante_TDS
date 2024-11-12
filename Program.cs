using SistemaGerenciamentoRestaurante.Controllers;
using SistemaGerenciamentoRestaurante.Data;
using SistemaGerenciamentoRestaurante.Services;
using SistemaGerenciamentoRestaurante.Models;

using Microsoft.EntityFrameworkCore;

namespace SistemaGerenciamentoRestaurante
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbContext = new RestauranteDbContext();
            var mesaController = new MesaController(dbContext);
            var itemController = new ItemCardapioController(dbContext);
            var pedidoService = new PedidoService(dbContext);

            // Exemplo de uso
            mesaController.AdicionarMesa(1);
            itemController.AdicionarItemCardapio("Pizza", 29.90m, "Principal");
            pedidoService.CriarPedido(1, new List<PedidoItem>
            {
                new PedidoItem { ItemId = 1, Quantidade = 2 }
            });

            Console.WriteLine("Sistema de Restaurante iniciado com sucesso!");
        }
    }
}