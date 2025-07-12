using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public InventoryManager inventory;
    public GameObject InventoryPanel;
    public GameObject slotPrefab;
    public List<GameObject> slotList = new List<GameObject>();

    void Start()
    {
        slotList.Add(InventoryPanel.GetComponentInChildren<RectTransform>().gameObject);
        RefreshUI();
    }
    public void RefreshUI()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject slot = slotList[i];
            GameObject item = Instantiate(gameObject);
            item.AddComponent<Image>();
            item.transform.SetParent(slot.transform);
            item.GetComponent<Image>().sprite = inventory.items[i].icon;
        }
    }
}
