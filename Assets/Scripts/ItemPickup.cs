using System.Collections;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemSO item;
    public int amount = 1;


    public void AddItemToInv(Inventory inv)
    {
        bool added = inv.AddItem(item, amount);
        if (added) Destroy(gameObject);
        else Debug.Log("Envanter dolu!");
    }
}
