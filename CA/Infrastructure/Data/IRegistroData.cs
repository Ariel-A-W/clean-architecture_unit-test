using CA.Domain.Entities.Registros;

namespace CA.Infrastructure.Data;

public interface IRegistroData
{
    List<RegistroEntity> GetDatas(); 
}
