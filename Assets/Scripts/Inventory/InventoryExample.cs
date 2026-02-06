using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    private void Start()
    {
        Item sword = new Item("Sword", 1);
        Item potionStack = new Item("Potion", 5);

        List<Item> starterItems = new List<Item> { sword, potionStack };
        Inventory inventory = new Inventory(starterItems, 10);

        Debug.Log($"Inventory created. Size: {inventory.CurrentSize}/{inventory.MaxSize}");
        Debug.Log("--- Inventory before adding ---");
        PrintInventory(inventory);

        Item newPotions = new Item("Potion", 3);

        if (inventory.CanAdd(newPotions))
        {
            inventory.Add(newPotions);
            Debug.Log($"Added 3 Potions.");
        }

        Debug.Log("--- Inventory after adding ---");
        PrintInventory(inventory);

        Item tooManyItems = new Item("Stone", 100);

        if (inventory.CanAdd(tooManyItems) == false)
            Debug.Log("Cannot add 100 stones (Not enough space).");

        Debug.Log("Trying to get 6 Potions...");
        List<Item> takenPotions = inventory.GetItemsBy("Potion", 6);

        if (takenPotions.Count > 0)
        {
            int totalTaken = takenPotions.Sum(i => i.Count);
            Debug.Log($"Successfully took {totalTaken} Potions.");
        }
        else
            Debug.Log("Failed to take potions.");

        Debug.Log($"Final Inventory Size: {inventory.CurrentSize}/{inventory.MaxSize}");
        PrintInventory(inventory);
    }

    private void PrintInventory(Inventory inventory)
    {
        foreach (var item in inventory.Items)
            Debug.Log($"Item: {item.Name}, Count: {item.Count}");
    }
}
