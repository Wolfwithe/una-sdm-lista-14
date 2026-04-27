using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CacauShowApi324123267.Data;
using CacauShowApi324123267.Models;
namespace CacauShowApi324123267.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly AppDbContext _context;

    public PedidoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Criar(Pedido pedido)
    {
        var unidade = _context.Franquias.Find(pedido.UnidadeId);
        var produto = _context.Produtos.Find(pedido.ProdutoId);

        if (unidade == null || produto == null)
            return NotFound("Unidade ou Produto não encontrado.");

        var totalItens = _context.Pedidos
            .Where(p => p.UnidadeId == pedido.UnidadeId)
            .Sum(p => p.Quantidade);

        if (totalItens + pedido.Quantidade > unidade.CapacidadeEstoque)
        {
            return BadRequest("Capacidade logística da loja excedida.");
        }

        pedido.ValorTotal = produto.PrecoBase * pedido.Quantidade;

        if (produto.Tipo == "Sazonal")
        {
            pedido.ValorTotal += 15;
            Console.WriteLine("Produto sazonal detectado: Adicionando embalagem premium!");
        }

        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        return Ok(pedido);
    }
}