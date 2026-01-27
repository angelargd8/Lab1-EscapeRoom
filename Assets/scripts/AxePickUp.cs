using UnityEngine;

public class AxePickUp : MonoBehaviour
{
    public Transform objectAnchor;
    public Collider pickupCollider;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        transform.SetParent(objectAnchor);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        PlayerInventory.hasAxe = true;
        PlayerInventory.heldAxe = gameObject;

        // desactivar solo el collider que era para recoger
        if (pickupCollider != null) pickupCollider.enabled = false;
    }
}
