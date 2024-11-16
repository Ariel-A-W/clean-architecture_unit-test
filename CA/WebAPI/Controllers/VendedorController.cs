using CA.Application.Interfaces;
using CA.Application.Services.Entities;
using CA.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CA.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VendedorController : ControllerBase
{
    private readonly IVendedorService _vendedor;
    private readonly IVendedorPorVentasService<VendedorPorVentasEntity> _vendedorPorVenta;

    public VendedorController(
        IVendedorService vendedor,
        IVendedorPorVentasService<VendedorPorVentasEntity> vendedorPorVenta
    )
    {
        _vendedor = vendedor;
        _vendedorPorVenta = vendedorPorVenta;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendedorResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IList<VendedorResponseDTO>> Get()
    {
        var vendedores = _vendedor.GetAll();

        if (vendedores == null || vendedores.Count() == 0)
            return NotFound("No existen registros en la lista.");

        List<VendedorResponseDTO> lstVendedores = new ();

        foreach (var item in vendedores)
        {
            lstVendedores.Add(
                new VendedorResponseDTO() 
                { 
                    Id = item.ID!.Value, 
                    Nombre = item.Nombre!.Value, 
                    Comision = item.Comision!.Value
                }    
            );
        }

        return Ok(lstVendedores);
    }

    [HttpGet("getbyid")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendedorResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VendedorResponseDTO> GetById(
        [FromQuery] VendedorPorVentasRequestDTO dto
    )
    {
        var vendedor = _vendedor.GetById(dto.Id);

        if (vendedor == null)
            return NotFound("No existe el vendedor.");

        var outVendedor = new VendedorResponseDTO()
        {
            Id = vendedor.ID!.Value,
            Nombre = vendedor.Nombre!.Value,
            Comision = vendedor.Comision!.Value
        };

        return Ok(outVendedor);
    }

    [HttpGet("vendedorporventa")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendedorResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VendedorPorVentasResponseDTO> VendendorPorVenta(int id)
    {
        try
        {
            var vendedorPorVenta = _vendedorPorVenta.GetById(id);

            if (vendedorPorVenta == null)
                return NotFound("No existe el vendedor y su ventas.");

            var lstRegs = new List<RegistroEntity>(); 
            if (vendedorPorVenta.Registros! == null)
                return BadRequest("Solictud errónea no aceptada."); 

            foreach (var item in vendedorPorVenta.Registros!)
            {
                lstRegs.Add(
                    new RegistroEntity()
                    {
                        Id = item.Id,
                        VendedorId = item.VendedorId,
                        Producto = item.Producto,
                        Comision = item.Comision,
                        Cantidad = item.Cantidad,
                        Unitario = item.Unitario,
                        IVA = item.IVA,
                        Monto = item.Monto,
                        MontoMasIVA = item.MontoMasIVA
                    }
                );
            }

            var outVendedorPorVenta = new VendedorPorVentasResponseDTO()
            {
                Id = vendedorPorVenta.Id,
                Nombre = vendedorPorVenta.Nombre,
                Comision = vendedorPorVenta.Comision,
                Registros = lstRegs,
                Ventas = vendedorPorVenta.Ventas,
            };

            return Ok(outVendedorPorVenta);
        }
        catch (Exception)
        { 
            return BadRequest("Solictud errónea no aceptada.");
        }
    }
}
// https://localhost:7154/vendedor/vendedorporventa?id=2