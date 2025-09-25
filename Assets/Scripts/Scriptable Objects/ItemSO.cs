using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite icon;
    public bool isStackable = true;
    public int slotIndex;
    public GameObject pickupPrefab;
}
