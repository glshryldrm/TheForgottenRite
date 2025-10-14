using System.Collections;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemSO item;
    public int amount = 1;

private void OnTriggerEnter2D(Collider2D other)
{
    StartCoroutine(DelayedPickup(other));
}

private IEnumerator DelayedPickup(Collider2D other)
{
    yield return new WaitForSeconds(0.2f); // küçük gecikme
    var inv = other.GetComponentInChildren<Inventory>();
    if (inv != null)
    {
        bool added = inv.AddItem(item, amount);
        if (added) Destroy(gameObject);
        else Debug.Log("Envanter dolu!");
    }
}
}
