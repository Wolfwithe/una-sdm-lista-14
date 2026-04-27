using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CacauShowApi324123267.Data;
using CacauShowApi324123267.Models;
namespace CacauShowApi324123267.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LoteProducaoController : ControllerBase
{
    private readonly AppDbContext _context;

    public LoteProducaoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Criar(LoteProducao lote)
    {
        var produto = _context.Produtos.Find(lote.ProdutoId);
        if (produto == null)
            return NotFound("Produto não existe.");

        if (lote.DataFabricacao > DateTime.Now)
            return Conflict("Lote inválido: Data de fabricação não pode ser maior que a data atual.");

        _context.Lotes.Add(lote);
        _context.SaveChanges();

        return Ok(lote);
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarStatus(int id, [FromBody] string novoStatus)
    {
        var lote = _context.Lotes.Find(id);
        if (lote == null) return NotFound();

        if (lote.Status == "Descartado" &&
           (novoStatus == "Qualidade Aprovada" || novoStatus == "Distribuído"))
        {
            return BadRequest("Regra violada: Lote descartado não pode voltar.");
        }

        lote.Status = novoStatus;
        _context.SaveChanges();

        return Ok(lote);
    }
}