using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Stores item names and their counts (e.g., "Arrow": 3)
    public Dictionary<string, int> Items = new Dictionary<string, int>();

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemName, int quantity = 1)
    {
        if (Items.ContainsKey(itemName))
        {
            Items[itemName] += quantity;
        }
        else
        {
            Items.Add(itemName, quantity);
        }

        Debug.Log($"Added {quantity} {itemName}. Total: {Items[itemName]}");
    }
}