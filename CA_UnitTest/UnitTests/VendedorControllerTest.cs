using CA.Application.Services;
using CA.Infrastructure.Data;
using CA.Infrastructure.Repositories;
using CA.WebAPI.Controllers;
using CA.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CA_UnitTest.UnitTests;

public class VendedorControllerTest
{
    private readonly VendedorController _controller;

    public VendedorControllerTest()
    {
        var vendedoresContent = new VendedorData();
        var vendedoresPorVentaContent = new RegistroData();

        var vendedores = new VendedorRepository(vendedoresContent!);
        var vendedorServicio = new VendedorService(vendedores);

        var vendedorPorVenta = new RegistroRepository(vendedoresPorVentaContent!);
        var vendedorPorventaServicio = new VendedorPorVentasService(vendedores, vendedorPorVenta);

        _controller = new VendedorController(vendedorServicio!, vendedorPorventaServicio!);
    }

    [Fact]
    public void Get_ShouldReturnOkResult_WithRealData()
    {
        var result = _controller.Get();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var vendedores = Assert.IsType<List<VendedorResponseDTO>>(okResult.Value);

        Assert.Equal(4, vendedores.Count);
    }

    [Fact]
    public void GetById_ShouldReturnOkResult_WithRealData()
    {
        var requestDto = new VendedorPorVentasRequestDTO { Id = 2 };

        var result = _controller.GetById(requestDto);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var vendedor = Assert.IsType<VendedorResponseDTO>(okResult.Value);

        Assert.Equal("Anamaría Rosa González", vendedor.Nombre);
    }

    [Fact]
    public void VendendorPorVenta_ShouldReturnOkResult_WithRealData()
    {
        var result = _controller.VendendorPorVenta(1);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var vendedorPorVenta = Assert.IsType<VendedorPorVentasResponseDTO>(okResult.Value);

        Assert.Equal("Carlos Alberto Quesada", vendedorPorVenta.Nombre);
        Assert.Equal(2, vendedorPorVenta.Registros!.Count);
    }
}
