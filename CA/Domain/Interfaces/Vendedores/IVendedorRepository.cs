using CA.Domain.Entities.Vendedores;
using CA.Domain.Interfaces.Abstractions;

namespace CA.Domain.Interfaces.Vendedores;

public interface IVendedorRepository : 
    IGetAll<Vendedor>, 
    IGetById<Vendedor>, 
    IAdd<Vendedor>, 
    IDelete, 
    IUpdate<Vendedor>;
