using System;
using System.Collections.Generic;
namespace CacauShowApi324123267.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; } // Gourmet, Linha Regular, Sazonal
    public decimal PrecoBase { get; set; }

    public List<LoteProducao>? Lotes { get; set; }
}