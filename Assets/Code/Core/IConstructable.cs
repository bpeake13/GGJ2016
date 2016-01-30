using UnityEngine;
using System.Collections;

/// <summary>
/// An object that can be constructed.
/// </summary>
/// <typeparam name="T">The constructor parameter type.</typeparam>
public interface IConstructable<T>
{
    void Construct(T paramater);
}
