using CA.Application.Services.Entities;

namespace CA.WebAPI.DTOs;

public class VendedorPorVentasResponseDTO
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public decimal Comision { get; set; }
    public IList<RegistroEntity>? Registros { get; set; }
    public VentasEntity? Ventas { get; set; }
}
