using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemSO item;
    public int amount;
    public int SlotIndex;

    public bool IsEmpty => item == null;
    public void Clear() { item = null; amount = 0; }
}
public class Inventory : MonoBehaviour
{
    public int capacity = 32;
    public List<InventorySlot> slots;

    public event Action OnInventoryChanged;

    private void Start()
    {
        slots = new List<InventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
        {
            slots.Add(new InventorySlot());
              slots[i].SlotIndex = i;
        }
    }
    public bool AddItem(ItemSO item, int amont = 1)
    {
        if (item == null) return false;

        if (item.isStackable)
        {
            foreach (var slot in slots)
            {
                if (!slot.IsEmpty && slot.item == item)
                {
                    slot.amount += amont;
                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }
        }

        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.item = item;
                slot.amount = amont;
                item.slotIndex = slot.SlotIndex;
                OnInventoryChanged?.Invoke();
                return true;
            }
        }

        return false;
    }

    public bool RemoveItem(ItemSO item, int amont = 1)
    {
        int slotIndex = item.slotIndex;
        if (slotIndex < 0 || slotIndex >= slots.Count) return false;
        if (slots[slotIndex].IsEmpty) return false;

        slots[slotIndex].amount -= amont;
        if (slots[slotIndex].amount <= 0) slots[slotIndex].Clear();
        OnInventoryChanged?.Invoke();
        return true;
    }
}
