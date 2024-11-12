using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoRestaurante.Models;
using SistemaGerenciamentoRestaurante.Services;

namespace SistemaGerenciamentoRestaurante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // Endpoint para criar um novo pedido
        [HttpPost]
        public IActionResult CriarPedido(int mesaId, [FromBody] List<PedidoItem> itens)
        {
            try
            {
                // Cria o pedido com os itens e mesaId
                var pedido = _pedidoService.CriarPedido(mesaId, itens);
                
                // Retorna a confirmação do pedido criado com sucesso
                return Ok($"Pedido criado com sucesso! ID: {pedido.Id}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar pedido: {ex.Message}");
            }
        }

        // Endpoint para gerar relatório de vendas
        [HttpGet("relatorio")]
        public IActionResult GerarRelatorioVendas(DateTime data) // Adicionando o parâmetro de data
        {
            try
            {
                // Passando a data para o serviço de relatório
                var totalVendas = _pedidoService.GerarRelatorioVendas(data);
                return Ok(totalVendas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao gerar relatório de vendas: {ex.Message}");
            }
        }
    }
}