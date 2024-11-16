using CA.Domain.Entities.Vendedores;
using CA.Domain.Interfaces.Vendedores;
using CA.Infrastructure.Data;

namespace CA.Infrastructure.Repositories;

public class VendedorRepository : IVendedorRepository
{
    private readonly IVendedorData _vendedor;

    public VendedorRepository(IVendedorData vendedor)
    {
        _vendedor = vendedor;
    }

    public IEnumerable<Vendedor> GetAll()
    {
        return _vendedor.GetDatas();
    }

    public Vendedor GetById(int id)
    {
        return _vendedor
            .GetDatas()
            .FirstOrDefault(x => x.ID!.Value == id)!;
    }

    public int Add(Vendedor entity)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public int Update(int id, Vendedor entity)
    {
        throw new NotImplementedException();
    }
}
