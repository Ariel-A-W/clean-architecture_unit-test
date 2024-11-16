namespace CA.Domain.Interfaces.Abstractions;

public interface IAdd<T> 
    where T : class
{
    int Add(T entity);
}
