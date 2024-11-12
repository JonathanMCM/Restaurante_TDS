using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoRestaurante.Data;
using SistemaGerenciamentoRestaurante.Models;
using SistemaGerenciamentoRestaurante.Services;


namespace SistemaGerenciamentoRestaurante.Controllers
{
    public class ItemCardapioController
    {
        private readonly RestauranteDbContext _context;

        public ItemCardapioController(RestauranteDbContext context)
        {
            _context = context;
        }

        public void AdicionarItemCardapio(string nome, decimal preco, string categoria)
        {
            var item = new ItemCardapio { Nome = nome, Preco = preco, Categoria = categoria };
            _context.ItensCardapio.Add(item);
            _context.SaveChanges();
        }

        public void ListarCardapio()
        {
            var itens = _context.ItensCardapio.ToList();
            foreach (var item in itens)
            {
                Console.WriteLine($"Item: {item.Nome}, Preço: {item.Preco}, Categoria: {item.Categoria}");
            }
        }
    }
}

