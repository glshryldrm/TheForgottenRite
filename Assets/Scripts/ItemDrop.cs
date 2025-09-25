using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Inventory inv; // Player'�n Inventory'si

    public void DropItem(ItemSO item, int amount)
    {
        if (inv.RemoveItem(item, amount))
        {
            if (item.pickupPrefab != null)
            {
                Vector3 dropPos = transform.position + new Vector3(0, 1f, 0); // biraz yukar� b�rak
                GameObject dropped = Instantiate(item.pickupPrefab, dropPos, Quaternion.identity);

                ItemPickup pickup = dropped.GetComponent<ItemPickup>();
                if (pickup != null)
                {
                    pickup.item = item;
                    pickup.amount = amount;
                }
            }
            else
            {
                Debug.LogWarning($"{item.name} i�in pickupPrefab atanmad�!");
            }
        }
        else
        {
            Debug.Log("Envanterde item yok veya miktar eksik!");
        }
    }
}
