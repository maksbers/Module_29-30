using System;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    private void Start()
    {
        Item sword = new Item("Sword");
        Item potion = new Item("Potion");

        Inventory inventory = new Inventory(10);

        Debug.Log($"Inventory created. Max Size: {inventory.MaxSize}");

        try
        {
            inventory.Add(sword, 1);
            inventory.Add(potion, 5);
        }
        catch (Exception exception)
        {
            Debug.LogError(exception.Message);
        }

        Debug.Log("--- Inventory before adding ---");
        PrintInventory(inventory);

        Item newPotion = new Item("Potion");

        if (inventory.CanAdd(3))
        {
            inventory.Add(newPotion, 3);
            Debug.Log($"Added 3 Potions.");
        }

        Debug.Log("--- Inventory after adding ---");
        PrintInventory(inventory);

        Item stone = new Item("Stone");
        Debug.Log("Trying to add 100 stones...");

        try
        {
            inventory.Add(stone, 100);
        }
        catch (InvalidOperationException exception)
        {
            Debug.Log($"Caught exception: {exception.Message}");
        }

        Debug.Log("Trying to take 6 Potions...");
        bool success = inventory.TryRemove("Potion", 6);

        if (success)
            Debug.Log($"Successfully took 6 Potions.");
        else
            Debug.Log("Failed to take potions.");

        Debug.Log($"Final Inventory Size: {inventory.CurrentSize}/{inventory.MaxSize}");
        PrintInventory(inventory);
    }

    private void PrintInventory(Inventory inventory)
    {
        foreach (var slot in inventory.Slots)
            Debug.Log($"Item: {slot.Item.Name}, Amount: {slot.Amount}");
    }
}
