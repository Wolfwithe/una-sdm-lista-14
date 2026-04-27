namespace CacauShowApi324123267.Models;
public class Pedido
{
    public int Id { get; set; }

    public int UnidadeId { get; set; }
    public Franquia? Unidade { get; set; } // 👈 AQUI

    public int ProdutoId { get; set; }
    public Produto? Produto { get; set; } // 👈 AQUI

    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
}