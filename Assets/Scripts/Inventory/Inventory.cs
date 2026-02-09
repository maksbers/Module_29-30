using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<InventorySlot> _slots = new();

    public Inventory(int maxSize)
    {
        MaxSize = maxSize;
    }

    public int MaxSize { get; private set; }

    public int CurrentSize => _slots.Sum(slot => slot.Amount);

    public IReadOnlyList<InventorySlot> Slots => _slots;

    public bool CanAdd(int amount) => CurrentSize + amount <= MaxSize;

    public void Add(Item item, int amount)
    {
        if (CanAdd(amount) == false)
            throw new InvalidOperationException($"Inventory is full. Cannot add {amount} of {item.Name}");

        InventorySlot existingSlot = _slots.FirstOrDefault(slot => slot.Item.Name == item.Name);

        if (existingSlot != null)
            existingSlot.Amount += amount;
        else
            _slots.Add(new InventorySlot(item, amount));
    }

    public bool TryRemove(string name, int count)
    {
        InventorySlot slot = _slots.FirstOrDefault(slot => slot.Item.Name == name);

        if (slot == null)
            return false;

        if (slot.Amount < count)
            return false;

        slot.Amount -= count;

        if (slot.Amount == 0)
            _slots.Remove(slot);

        return true;
    }

    public bool HasItem(string name, int count)
    {
        InventorySlot slot = _slots.FirstOrDefault(slot => slot.Item.Name == name);
        return slot != null && slot.Amount >= count;
    }
}