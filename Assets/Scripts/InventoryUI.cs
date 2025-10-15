using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsParent;
    public GameObject slotPrefab;
    public GameObject player;
    public static  InventoryUI Instance;

    private ItemDrop playerDrop;
    private Inventory inventory;

    private List<SlotUI> slotUIs = new List<SlotUI>();

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        inventory = player.GetComponentInChildren<Inventory>();
        playerDrop = player.GetComponent<ItemDrop>();
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
    //public void RefreshUI()
    //{
    //    for (int i = 0; i < inventory.slots.Count; i++)
    //    {
    //        InventorySlot data = inventory.slots[i];
    //        if (data.IsEmpty)
    //            slotUIs[i].SetEmpty();
    //        else
    //        {
    //            slotUIs[i].SetItem(data.item.icon, data.amount);
    //            slotUIs[i].Setup(data.SlotIndex, playerInv.GetComponentInParent<ItemDrop>());
    //        }


    //    }
    //}
    public void RefreshUI()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            InventorySlot data = inventory.slots[i];
            SlotUI slotUI = slotUIs[i];
            slotUI.slotIndex = i; // her seferinde senkronize et

            if (data.IsEmpty)
            {
                slotUI.SetEmpty();
            }
            else
            {
                slotUI.SetItem(data.item, data.amount, playerDrop);
            }
        }
    }

    public void ChangeEnabled()
    {
        this.gameObject.SetActive(!gameObject.activeSelf);
    }
}
