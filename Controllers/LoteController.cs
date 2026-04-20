using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CacauShowApi324123267.Data;
using CacauShowApi324123267.Models;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324123267.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class LoteController : ControllerBase
    {
        private readonly AppDbcontext _Context;

    
    public LoteController(AppDbcontext context)
        {
            _Context = context;

        }
        //Criar Lote
        [HttpPost]
        public IActionResult CriarLoteProducao(LoteProducao loteProducao)
        {
            _Context.LoteProducaos.Add(loteProducao);
            _Context.SaveChanges();

            return Ok(loteProducao);

        }

        [HttpPost]
        public async Task<IActionResult> Post(LoteProducao lote)

        {
            var ProdutoExiste = await _Context.Produtos.AnyAsync(Produto =>  Produto.Id == lote.ProdutoId);
            if(!ProdutoExiste)
            {
                return BadRequest($"Lote inválido: O preoduto com Id{lote.ProdutoId}não existe");

            }
            if(lote.DataFabricacao > DateTime.Now)
            {
                return Conflict("Lote inváldio: Data de fabricação não pode ser maior que a data atual");
            }
            _Context.LoteProducaos.Add(lote);
            await _Context.SaveChangesAsyncaa();
            return Ok();

        }
        //mostrar lote
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_Context.LoteProducaos.ToList());
        }
    }
}