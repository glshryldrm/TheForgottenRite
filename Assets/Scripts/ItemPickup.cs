using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemSO item;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var inv = other.GetComponentInChildren<Inventory>();
        if (inv != null)
        {
            bool added = inv.AddItem(item, amount);
            if (added) Destroy(gameObject); // al�nd�ysa nesneyi yok et
            else Debug.Log("Envanter dolu!");
        }
    }
}
