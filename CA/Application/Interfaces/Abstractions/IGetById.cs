﻿namespace CA.Application.Interfaces.Abstractions;

public interface IGetById<T> 
    where T : class
{
    T GetById(int id);
}