namespace CacauShowApi324123267.Models;
public class Franquia
{
    public int Id { get; set; }
    public string NomeLoja { get; set; }
    public string Cidade { get; set; }
    public int CapacidadeEstoque { get; set; }

    public List<Pedido>? Pedidos { get; set; }
}