using CA.Domain.ValueObjects.Ventas;

namespace CA.Domain.Entities.Ventas;

public class Venta
{
    public TotalVenta? TotalVenta { get; set; }
    public Comision? Comision { get; set; }
    public Bono? Bono { get; set; }
    public Total? Total { get; set; }
}
