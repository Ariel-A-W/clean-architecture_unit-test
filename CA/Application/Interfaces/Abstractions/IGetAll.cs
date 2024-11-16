namespace CA.Application.Interfaces.Abstractions;

public interface IGetAll<T> 
    where T : class
{
    IEnumerable<T> GetAll(); 
}
