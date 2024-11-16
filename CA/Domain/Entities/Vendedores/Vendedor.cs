using CA.Domain.ValueObjects.Abstracts;
using CA.Domain.ValueObjects.Vendedores;

namespace CA.Domain.Entities.Vendedores;

public class Vendedor
{
    public ID? ID { get; set; }
    public Nombre? Nombre { get; set; }
    public Comision? Comision { get; set; }
}
