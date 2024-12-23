﻿namespace CA.Application.Interfaces.Abstractions;

public interface IUpdate<T> 
    where T : class
{
    int Update(int id, T entity);
}
