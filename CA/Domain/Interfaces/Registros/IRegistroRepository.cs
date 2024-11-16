using CA.Domain.Entities.Registros;
using CA.Domain.Interfaces.Abstractions;

namespace CA.Domain.Interfaces.Registros;

public interface IRegistroRepository :
    IGetAll<RegistroEntity>,
    IGetById<RegistroEntity>
{
    IEnumerable<RegistroEntity> GetByIdVendedor(int id);
}
