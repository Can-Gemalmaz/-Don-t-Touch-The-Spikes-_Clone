using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MyList<T>
{
    private int _capacity;
    private T[] _array;
    private int _count = 0;


    public int Count
    {
        get { return _count; }
    }

    public MyList(int capacity)
    {
        _capacity = capacity;
        _array = new T[capacity];
    }

    public void Add(T value)
    {
        if (_count == _capacity)
        {
            _capacity *= 2;
            T[] newArray = new T[_capacity];
            Array.Copy(_array, newArray, _count);
            _array = newArray;
        }
        _array[_count++] = value;
    }

    public bool Remove<T>(int index)
    {
        if (index >= _count || index < 0)
        {
            return false;
        }
        for (int i = index; i < _count - 1; i++)
        {
            _array[i] = _array[i + 1];
        }

        _array[--_count] = default;
        return true;
    }

    public bool Remove<T>(T value)
    {
        int index = Array.IndexOf(_array, value, 0, _count);
        if (index < 0)
        {
            return false;
        }
        return Remove(index);

    }

    public void Clear()
    {
        _array = new T[_capacity];
        _count = 0;
    }

    public bool Contains(T value)
    {
        return Array.IndexOf(_array, value, 0, _count) >= 0;
    }
    public T GetValue(int index)
    {
        //todo: add index range control 
        return _array[index];
    }
    public T this[int i]
    {
        get
        {
            //todo: add index range control 
            return _array[i];
        }
        set
        {
            //todo: add index range control 
            _array[i] = value;
        }
    }
}
