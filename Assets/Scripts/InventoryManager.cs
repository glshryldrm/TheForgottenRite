using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int maxSlots = 20;

    public bool AddItem(Item newItem)
    {
        if (items.Count >= maxSlots)
        {
            Debug.Log("Envanter dolu!");
            return false;
        }

        items.Add(newItem);
        // UI güncelleme burada çaðrýlabilir
        return true;
    }

    public void RemoveItem(Item itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
        }
    }
}
