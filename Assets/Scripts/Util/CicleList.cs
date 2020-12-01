using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicleList<T>
{
    public int Count => _array.Count;

    private List<T> _array;
    private int _indexArray;

    public CicleList()
    {
        _indexArray = 0;
        _array = new List<T>();
    }

    public void Add(T value) => _array.Add(value);

    public void AddRange(List<T> values) => _array.AddRange(values);

    public void AddRange(T[] values) => _array.AddRange(values);

    public T Current() => _array[_indexArray];

    public T Next() => Get(1);

    public T Last() => Get(-1);

    public T Get(int value)
    {
        _indexArray =+ value;

        if (_indexArray > _array.Count - 1)
            _indexArray = 0;

        if (_indexArray < 0)
            _indexArray = _array.Count - 1;

        return _array[_indexArray];
    }

    public void Clear()
    {
        _array.Clear();
        _indexArray = 0;
    }

}
