using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Vector3 cp = other.transform.position;
        TransportCollider(cp);
    }

    void TransportCollider(Vector3 col)
    {
        col.y += 5f;
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 cp = other.transform.position;
        cp.y -= 5f;
    }
}
