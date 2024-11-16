using CA.Application.Interfaces.Abstractions;
using CA.Domain.Entities.Vendedores;

namespace CA.Application.Interfaces;

public interface IVendedorService :
    IGetAll<Vendedor>,
    IGetById<Vendedor>;
