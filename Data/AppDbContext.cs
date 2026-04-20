using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacauShowApi324123267.Models;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324123267.Data
{
   public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext>options): base(options)
        {
            
        }
        
        public DbSet <Franquia> Franquias {get; set;}
        public DbSet<LoteProducao> LoteProducaos {get;set;}
        public DbSet <Pedido> Pedidos{get; set;}
        public DbSet<Produto> Produtos {get; set;}

        internal async Task SaveChangesAsyncaa()
        {
            throw new NotImplementedException();
        }
    }
}