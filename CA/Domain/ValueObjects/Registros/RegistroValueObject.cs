namespace CA.Domain.ValueObjects.Registros;

public record VendedorId(int Value);
public record Producto(string Value);
public record Cantidad(int Value);
public record Unitario(decimal Value);
public record IVA(decimal Value);
public record Monto(
    int Cantidad, decimal Unitario
)
{
    public decimal GetMonto(int Cantidad, decimal Unitario)
    {
        decimal resultado = 0.0M;

        if (Cantidad == 0 || Unitario == 0)
            new ArgumentException("Los valores no pueden ser cero.");

        resultado = Cantidad * Unitario;

        return resultado;
    }
}
public record MontoMasIVA(
    int Cantidad, decimal Unitario, decimal IVA
)
{
    public decimal GetMontoMasIVA(int Cantidad, decimal Unitario, decimal IVA)
    {
        decimal resultado = 0.0M;

        if (Cantidad == 0 || Unitario == 0)
            new ArgumentException("Los valores no pueden ser cero.");

        resultado = Cantidad * Unitario + Cantidad * Unitario * IVA / 100;

        return resultado;
    }
}
