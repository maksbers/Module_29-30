public class InventorySlot
{
    public InventorySlot(IReadOnlyItem item, int amount)
    {
        Item = item;
        Amount = amount;
    }

    public IReadOnlyItem Item { get; }
    public int Amount { get; set; }
}
