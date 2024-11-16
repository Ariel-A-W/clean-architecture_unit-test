using CA.Domain.ValueObjects.Abstracts;
using CA.Domain.ValueObjects.Registros;

namespace CA.Domain.Entities.Registros;

public class RegistroEntity
{
    public ID? ID { get; set; }
    public VendedorId? VendedorId { get; set; }
    public Producto? Producto { get; set; }
    public Cantidad? Cantidad { get; set; }
    public Unitario? Unitario { get; set; }
    public IVA? IVA { get; set; }
    public Monto? Monto { get; set; }
    public MontoMasIVA? MontoMasIVA { get; set; }
}
