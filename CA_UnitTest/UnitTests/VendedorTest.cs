using CA.Application.Interfaces;
using CA.Application.Services.Entities;
using CA.Domain.Entities.Vendedores;
using CA.Domain.ValueObjects.Abstracts;
using CA.Domain.ValueObjects.Vendedores;
using CA.WebAPI.Controllers;
using CA.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CA_UnitTest.UnitTests;

public class VendedorTest
{
    private readonly Mock<IVendedorService> _mockVendedorService;
    private readonly Mock<IVendedorPorVentasService<VendedorPorVentasEntity>> _mockVendedorPorVentasService;
    private readonly VendedorController _controller;

    public VendedorTest()
    {
        _mockVendedorService = new Mock<IVendedorService>();
        _mockVendedorPorVentasService = new Mock<IVendedorPorVentasService<VendedorPorVentasEntity>>();
        _controller = new VendedorController(
            _mockVendedorService.Object,
            _mockVendedorPorVentasService.Object
        );
    }

    /// <summary>
    /// Prueba Optimista (Positiva) para Lista de los Vendedores. 
    /// </summary>
    [Fact]
    public void Get_ShouldReturnOkResult_WhenVendedoresExist()
    {
        // Instancias
        var vendedores = new List<Vendedor>
        {
            new Vendedor {
                ID = new ID(1),
                Nombre = new Nombre("Juan Pérez"),
                Comision = new Comision(0.1M)
            },
            new Vendedor {
                ID = new ID(2),
                Nombre = new Nombre("Ana López"),
                Comision = new Comision(0.15M)
            },
        };

        _mockVendedorService.Setup(s => s.GetAll()).Returns(vendedores);

        // Actuación
        var result = _controller.Get();

        // Aciertos
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<VendedorResponseDTO>>(okResult.Value);

        // Probar si realmente son dos registros existentes en la lista hardcodeada.
        Assert.Equal(2, returnValue.Count);
        // Probar si Juan Pérez existen en la lista.
        Assert.Equal("Juan Pérez", returnValue[0].Nombre);
    }

    /// <summary>
    /// Prueba Pesimista (Negativa) para Lista de los Vendedores.
    /// </summary>
    [Fact]
    public void Get_ShouldReturnNotFound_WhenNoVendedoresExist()
    {
        // Instancia
        _mockVendedorService.Setup(s => s.GetAll()).Returns(new List<Vendedor>());

        // Actuación
        var result = _controller.Get();

        // Acierto
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }
}
