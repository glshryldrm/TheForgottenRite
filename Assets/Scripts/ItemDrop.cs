using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ItemDrop : MonoBehaviour
{
    public Inventory inv;

    public void DropItem(int slotIndex, int amount)
    {
        InventorySlot slot = inv.slots[slotIndex];
        ItemSO itemToDrop = slot.item;

        if (inv.RemoveItem(slotIndex, amount))
        {
            Vector3 dropPos = transform.position + Vector3.up * 1.5f;

            // Prefab'ý Addressables üzerinden yükle
            Addressables.LoadAssetAsync<GameObject>(itemToDrop.pickupAddress).Completed += (op) =>
            {
                if (op.Status == AsyncOperationStatus.Succeeded)
                {
                    GameObject prefab = op.Result;
                    GameObject dropped = Instantiate(prefab, dropPos, Quaternion.identity);

                    ItemPickup pickup = dropped.GetComponent<ItemPickup>();
                    if (pickup != null)
                    {
                        pickup.item = itemToDrop;
                        pickup.amount = amount;
                    }

                    Debug.Log($"{itemToDrop.itemName} baþarýyla droplandý!");
                }
                else
                {
                    Debug.LogWarning($"Addressables prefab yüklenemedi: {itemToDrop.pickupAddress}");
                }
            };
        }
    }
}
