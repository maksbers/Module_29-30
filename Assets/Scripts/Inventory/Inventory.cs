using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Item> _items = new();

    public int MaxSize { get; private set; }
    public int CurrentSize => _items.Sum(item => item.Count);

    public IReadOnlyList<IReadOnlyItem> Items => _items;

    public Inventory(List<Item> items, int maxSize)
    {
        _items = items;

        if (maxSize < CurrentSize)
            throw new ArgumentOutOfRangeException(nameof(maxSize));

        MaxSize = maxSize;
    }

    public bool CanAdd(Item item)
    {
        return CurrentSize + item.Count <= MaxSize;
    }

    public void Add(Item item)
    {
        if (CanAdd(item) == false)
            return;

        Item existingItem = _items.FirstOrDefault(i => i.Name == item.Name);

        if (existingItem != null)
            existingItem.Count += item.Count;
        else
            _items.Add(item);
    }

    public List<Item> GetItemsBy(string name, int count)
    {
        List<Item> result = new();

        Item item = _items.FirstOrDefault(i => i.Name == name);

        if (item == null)
            return result;

        if (item.Count < count)
            return result;

        if (item.Count == count)
        {
            result.Add(item);
            _items.Remove(item);
        }
        else
        {
            Item splitItem = new Item(item.Name, count);
            result.Add(splitItem);
            item.Count -= count;
        }

        return result;
    }
}