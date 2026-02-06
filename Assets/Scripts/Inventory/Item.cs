public class Item : IReadOnlyItem
{
    public string Name { get; set; }
    public int Count { get; set; }

    public Item(string name, int count)
    {
        Name = name;
        Count = count;
    }
}
