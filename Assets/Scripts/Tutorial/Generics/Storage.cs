using System.Collections.Generic;
using UnityEngine;

public class Storage<T>
{
    private List<T> _items = new();

    public T GetRandom() => _items[Random.Range(0, _items.Count)];

    public void Add(T item)
    {
        if (_items.Contains(item))
        {
            Debug.LogWarning($"{nameof(item)} already in storage");
            return;
        }

        _items.Add(item);
    }

    public void Remove(T item)
    {
        if (_items.Contains(item) == false)
        {
            Debug.LogWarning($"{nameof(item)} not found in storage");
            return;
        }

        _items.Remove(item);
    }
}
