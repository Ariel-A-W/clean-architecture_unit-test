using CA.Application.Interfaces;
using CA.Application.Services.Entities;
using CA.Domain.Interfaces.Registros;
using CA.Domain.Interfaces.Vendedores;
using CA.Domain.ValueObjects.Ventas;

namespace CA.Application.Services;

public class VendedorPorVentasService 
    : IVendedorPorVentasService<VendedorPorVentasEntity>
{
    private readonly IVendedorRepository _vendedor;
    private readonly IRegistroRepository _registro;

    public VendedorPorVentasService(
        IVendedorRepository vendedor, 
        IRegistroRepository registro
    )
    {
        _vendedor = vendedor;
        _registro = registro;
    }

    public VendedorPorVentasEntity GetById(int id)
    {
        var vendedor = _vendedor.GetById(id);

        if (vendedor == null)
            return new VendedorPorVentasEntity();

        var registros = _registro.GetByIdVendedor(id);

        List<RegistroEntity> regsEnty = new ();
        var ventsEnty = new VentasEntity(); 

        decimal totalVenta = 0;

        foreach (var item in registros)
        {
            regsEnty.Add(
                new RegistroEntity() { 
                    Id = item.ID!.Value, 
                    VendedorId = item.VendedorId!.Value, 
                    Comision = vendedor.Comision!.Value,
                    Producto = item.Producto!.Value, 
                    Cantidad = item.Cantidad!.Value,
                    Unitario = item.Unitario!.Value,
                    IVA = item.IVA!.Value,
                    Monto = item.Monto!.GetMonto(
                        item.Cantidad!.Value, 
                        item.Unitario!.Value
                    ), 
                    MontoMasIVA = item.MontoMasIVA!.GetMontoMasIVA(
                        item.Cantidad!.Value,
                        item.Unitario!.Value,
                        item.IVA!.Value
                    )
                }    
            );
            totalVenta += item.MontoMasIVA!.GetMontoMasIVA(
                item.Cantidad!.Value,
                item.Unitario!.Value,
                item.IVA!.Value
            );
        }
        ventsEnty.TotalVenta = totalVenta;
        ventsEnty.Comision = vendedor.Comision!.Value;
        ventsEnty.Bono = new Bono(totalVenta).GetBono();
        ventsEnty.Total = new Total(
            totalVenta,
            new Bono(totalVenta).GetBono()
        ).GetTotal();

        var vendedoresPorVenta = new VendedorPorVentasEntity()
        {
            Id = vendedor.ID!.Value,
            Nombre = vendedor.Nombre!.Value,
            Comision = vendedor.Comision!.Value,
            Registros = regsEnty,
            Ventas = ventsEnty
        };

        return vendedoresPorVenta;
    }
}
