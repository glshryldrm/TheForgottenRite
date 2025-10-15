using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

public class PlayerInputHandler : MonoBehaviour
{
    private Camera cam;
    [SerializeField] LayerMask layer;
    [SerializeField] private float pickupRange = 1f;
    public static bool clickCheck = true;

    void Start()
    {

        cam = Camera.main;

    }
    void Update()
    {

        MoveWithRay();

    }

    private void MoveWithRay()
    {

        if (!clickCheck) return;

        if (Input.GetMouseButtonDown(0)) // Sol tık
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Raycast ile neye tıklandığını bul
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layer);

            if (hit.collider != null)
            {
                // Tıklanan objenin pozisyonu
                Transform itemTransform = hit.collider.transform;

                // Player ile item arasındaki mesafe
                float distance = Vector2.Distance(transform.position, itemTransform.position);

                // Mesafe kontrolü
                if (distance <= pickupRange)
                {
                    Debug.Log("Eşyayı alındı: " + hit.collider.name);
                    HandlePickup(hit.collider);
                }
                else
                {
                    Debug.Log("Çok uzaktasın, item alınamaz!");
                }
            }
        }
    }
    public void HandlePickup(Collider2D other)
    {
        var inv = GetComponentInChildren<Inventory>();
        if (inv != null)
        {
            other.GetComponent<ItemPickup>().AddItemToInv(inv);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }

}