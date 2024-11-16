namespace CA.Application.Services.Entities;

public class RegistroEntity
{
    public int Id { get; set; }
    public int VendedorId { get; set; }
    public decimal Comision { get; set; }
    public string? Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal Unitario { get; set; }
    public decimal IVA { get; set; }
    public decimal Monto { get; set; }
    public decimal MontoMasIVA { get; set; }
}
