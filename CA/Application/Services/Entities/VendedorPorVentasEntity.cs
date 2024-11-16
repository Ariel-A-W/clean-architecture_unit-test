namespace CA.Application.Services.Entities;

public class VendedorPorVentasEntity
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public decimal Comision { get; set; }
    public IList<RegistroEntity>? Registros { get; set; }
    public VentasEntity? Ventas { get; set; }
}
