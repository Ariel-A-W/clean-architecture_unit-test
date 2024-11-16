using CA.Domain.Entities.Registros;
using CA.Domain.ValueObjects.Abstracts;
using CA.Domain.ValueObjects.Registros;

namespace CA.Infrastructure.Data;

public class RegistroData : IRegistroData
{
    public List<RegistroEntity> GetDatas()
    {
        return new List<RegistroEntity>()
        {
            new RegistroEntity()
            {
                ID = new ID(1),
                VendedorId = new VendedorId(1),
                Producto = new Producto("Aceite Oliva Doble Prensado Extra"),
                Cantidad = new Cantidad(25000),
                Unitario = new Unitario(12.00M),
                IVA = new IVA(21.00M),
                Monto = new Monto(25000, 12.00M),
                MontoMasIVA = new MontoMasIVA(25000, 12.00M, 21.00M),
            },
            new RegistroEntity()
            {
                ID = new ID(2),
                VendedorId = new VendedorId(3),
                Producto = new Producto("Aceite de Girasol Natural"),
                Cantidad = new Cantidad(30000),
                Unitario = new Unitario(8.20M),
                IVA = new IVA(21.00M),
                Monto = new Monto(30000, 12.00M),
                MontoMasIVA = new MontoMasIVA(30000, 8.20M, 21.00M),
            },
            new RegistroEntity()
            {
                ID = new ID(3),
                VendedorId = new VendedorId(3),
                Producto = new Producto("Vinagre Manzana Extra"),
                Cantidad = new Cantidad(5000),
                Unitario = new Unitario(3.25M),
                IVA = new IVA(21.00M),
                Monto = new Monto(5000, 12.00M),
                MontoMasIVA = new MontoMasIVA(5000, 3.25M, 21.00M),
            },
            new RegistroEntity()
            {
                ID = new ID(4),
                VendedorId = new VendedorId(1),
                Producto = new Producto("Aceite Mezcla Extra"),
                Cantidad = new Cantidad(28000),
                Unitario = new Unitario(6.38M),
                IVA = new IVA(21.00M),
                Monto = new Monto(28000, 12.00M),
                MontoMasIVA = new MontoMasIVA(28000, 6.38M, 21.00M),
            },
            new RegistroEntity()
            {
                ID = new ID(5),
                VendedorId = new VendedorId(2),
                Producto = new Producto("Aceite Olica y Romero Extra"),
                Cantidad = new Cantidad(42000),
                Unitario = new Unitario(19.34M),
                IVA = new IVA(21.00M),
                Monto = new Monto(25000, 12.00M),
                MontoMasIVA = new MontoMasIVA(42000, 19.34M, 21.00M),
            },
                        new RegistroEntity()
            {
                ID = new ID(6),
                VendedorId = new VendedorId(4),
                Producto = new Producto("Vinagre Vino"),
                Cantidad = new Cantidad(15000),
                Unitario = new Unitario(0.780M),
                IVA = new IVA(21.00M),
                Monto = new Monto(15000, 12.00M),
                MontoMasIVA = new MontoMasIVA(15000, 0.780M, 21.00M),
            },
        };
    }
}
