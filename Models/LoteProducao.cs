namespace CacauShowApi324123267.Models;
public class LoteProducao
{
    public int Id { get; set; }
    public string CodigoLote { get; set; }
    public DateTime DataFabricacao { get; set; }

    public int ProdutoId { get; set; }

    public Produto? Produto { get; set; } // 👈 AQUI

    public string Status { get; set; }
}