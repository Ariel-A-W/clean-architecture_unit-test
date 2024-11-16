using System.ComponentModel.DataAnnotations;

namespace CA.WebAPI.DTOs;

public class VendedorPorVentasRequestDTO
{
    [Required(ErrorMessage = "El valor ID es requerido.")]
    public int Id { get; set; }
}
