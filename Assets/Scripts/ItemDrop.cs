using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Inventory inv; // Player'ýn Inventory'si

    public void DropItem(int slotIndex, int amount)
    {
        var slot = inv.slots[slotIndex];
        ItemSO itemToDrop = slot.item;
        if (inv.RemoveItem(slotIndex, amount))
        {
            if (itemToDrop.pickupPrefab != null)
            {
                Vector3 dropPos = transform.position + new Vector3(0, 1f, 0); // biraz yukarý býrak
                GameObject dropped = Instantiate(itemToDrop.pickupPrefab, dropPos, Quaternion.identity);

                ItemPickup pickup = dropped.GetComponent<ItemPickup>();
                if (pickup != null)
                {
                    pickup.item = itemToDrop;
                    pickup.amount = amount;
                }
            }
            else
            {
                Debug.LogWarning($"{itemToDrop.name} için pickupPrefab atanmadý!");
            }
        }
        else
        {
            Debug.Log("Envanterde item yok veya miktar eksik!");
        }
    }
}
