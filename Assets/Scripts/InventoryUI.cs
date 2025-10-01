using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform slotsParent;
    public GameObject slotPrefab;
    public GameObject playerInv;

    private List<SlotUI> slotUIs = new List<SlotUI>();

    private void Start()
    {
        // slot prefablarýndan UI oluþtur (veya inspector'da hazýr slotlarý al)
        for (int i = 0; i < inventory.capacity; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotsParent);

            SlotUI s = go.GetComponent<SlotUI>();
            s.slotIndex = i;
            slotUIs.Add(s);
        }


        inventory.OnInventoryChanged += RefreshUI;
        RefreshUI();
    }
    public void RefreshUI()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            var data = inventory.slots[i];
            if (data.IsEmpty)
                slotUIs[i].SetEmpty();
            else
            {
                slotUIs[i].SetItem(data.item.icon, data.amount);
                slotUIs[i].Setup(data.SlotIndex, playerInv.GetComponentInParent<ItemDrop>());
            }
                

        }
    }
    public void ChangeEnabled()
    {
        this.gameObject.SetActive(!gameObject.activeSelf);
    }
}
