using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoRestaurante.Data;
using SistemaGerenciamentoRestaurante.Models;
using SistemaGerenciamentoRestaurante.Services;


namespace SistemaGerenciamentoRestaurante.Controllers
{
    public class MesaController
    {
        private readonly RestauranteDbContext _context;

        public MesaController(RestauranteDbContext context)
        {
            _context = context;
        }

        public void AdicionarMesa(int numero)
        {
            var mesa = new Mesa { Numero = numero, Ocupada = false };
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
        }

        public void ListarMesas()
        {
            var mesas = _context.Mesas.ToList();
            foreach (var mesa in mesas)
            {
                Console.WriteLine($"Mesa {mesa.Numero}, Ocupada: {mesa.Ocupada}");
            }
        }
    }
}