using CA.Domain.Entities.Vendedores;
using CA.Application.Interfaces;
using CA.Domain.Interfaces.Vendedores;

namespace CA.Application.Services;

public class VendedorService : IVendedorService
{
    private readonly IVendedorRepository _vendedor;

    public VendedorService(IVendedorRepository vendedor)
    {
        _vendedor = vendedor;
    }

    public IEnumerable<Vendedor> GetAll()
    {
        return _vendedor.GetAll();
    }

    public Vendedor GetById(int id)
    {
        return _vendedor.GetById(id);
    }
}
