using CA.Domain.Entities.Vendedores;
using CA.Domain.ValueObjects.Abstracts;
using CA.Domain.ValueObjects.Vendedores;

namespace CA.Infrastructure.Data;

public class VendedorData : IVendedorData
{
    public List<Vendedor> GetDatas() {
        return new List<Vendedor>() { 
            new Vendedor() 
            { 
                ID = new ID(1), 
                Nombre = new Nombre("Carlos Alberto Quesada"), 
                Comision = new Comision(2.35M)
            },
            new Vendedor()
            {
                ID = new ID(2),
                Nombre = new Nombre("Anamaría Rosa González"),
                Comision = new Comision(3.25M)
            },
            new Vendedor()
            {
                ID = new ID(3),
                Nombre = new Nombre("Horacio Luis Díaz"),
                Comision = new Comision(3.45M)
            },
            new Vendedor()
            {
                ID = new ID(3),
                Nombre = new Nombre("María Stella Lucchio"),
                Comision = new Comision(2.75M)
            },
        };
    }
}
