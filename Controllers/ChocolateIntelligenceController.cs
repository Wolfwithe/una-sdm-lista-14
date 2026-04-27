using Microsoft.AspNetCore.Mvc;
using CacauShowApi324123267.Data;
using CacauShowApi324123267.Models;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324123267.Controllers;
[ApiController]
[Route("api/intelligence")]
public class ChocolateIntelligenceController : ControllerBase
{
    private readonly AppDbContext _context;

    public ChocolateIntelligenceController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("estoque-regional")]
    public IActionResult GetEstoqueRegional()
    {
        Thread.Sleep(2000);

        var resultado = _context.Pedidos
            .Include(p => p.Unidade)
            .GroupBy(p => p.Unidade.Cidade)
            .Select(g => new
            {
                Cidade = g.Key,
                TotalItens = g.Sum(p => p.Quantidade)
            }).ToList();

        return Ok(resultado);
    }
}