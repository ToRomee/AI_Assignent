using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Singleton mode
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseManager<T> where T : new() //make sure that the T has a constructor with no parameter
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = new T();
        }

        return instance;
    }
}
