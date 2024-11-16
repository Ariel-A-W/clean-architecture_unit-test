using CA.Application.Services.Entities;
using CA.Domain.Interfaces.Abstractions;

namespace CA.Domain.Interfaces.Ventas;

public interface IVentaRepository : 
    IGetAll<VentasEntity>, 
    IGetById<VentasEntity>;