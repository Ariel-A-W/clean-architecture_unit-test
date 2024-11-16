using CA.Domain.Entities.Registros;
using CA.Domain.Interfaces.Registros;
using CA.Infrastructure.Data;

namespace CA.Infrastructure.Repositories;

public class RegistroRepository : IRegistroRepository
{
    private readonly IRegistroData _registro;

    public RegistroRepository(IRegistroData registro)
    {
        _registro = registro;
    }

    public IEnumerable<RegistroEntity> GetAll()
    {
        return _registro.GetDatas();
    }

    public RegistroEntity GetById(int id)
    {
        return _registro
            .GetDatas()
            .FirstOrDefault(x => x.ID!.Value == id)!;
    }

    public IEnumerable<RegistroEntity> GetByIdVendedor(int id)
    {
        return _registro
            .GetDatas()
            .Where(x => x.VendedorId!.Value == id);
    }
}
