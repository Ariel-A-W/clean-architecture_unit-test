namespace CA.Domain.ValueObjects.Ventas;

public record VendedorId(int Value);
public record TotalVenta(decimal Value);
public record Comision(decimal TotalVenta, decimal ComisionVendedor)
{
    public decimal GetComision(
        decimal TotalVenta, decimal ComisionVendedor) 
            => TotalVenta * ComisionVendedor;
}
public record Bono(decimal Venta)
{
    public decimal GetBono() {
        if (Venta > 0 && Venta <= 20000)
        {
            return 0.0M;
        }
        else if (Venta >= 20001 && Venta <= 40000)
        {
            return 500.00M;
        }
        else if (Venta >= 40001 && Venta <= 60000)
        {
            return 1500.00M;
        }
        else
        {
            return 3000.00M;
        }
    }
}
public record TotalComision(decimal Bono, decimal Comision)
{ 
    public decimal GetTotalComision() => Bono * Comision;
}
public record Total(decimal TotalVenta, decimal Bono)
{
    public decimal GetTotal() 
    {
        return TotalVenta + Bono;
    }
}