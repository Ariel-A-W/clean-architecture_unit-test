using CA.Domain.Entities.Registros;

namespace CA.Application.Interfaces;

public interface IVendedorPorVentasService<T> 
    where T : class
{
    T GetById(int id);
}
