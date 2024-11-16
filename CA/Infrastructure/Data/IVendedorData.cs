using CA.Domain.Entities.Vendedores;

namespace CA.Infrastructure.Data;

public interface IVendedorData
{
    List<Vendedor> GetDatas();
}
