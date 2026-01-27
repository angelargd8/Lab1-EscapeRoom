using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public Transform objectAnchor;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // tomar llave
        transform.SetParent(objectAnchor);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // guardar llave en inventario
        PlayerInventory.hasKey = true;
        PlayerInventory.heldKey = gameObject;

        // Evitar que se vuelva a activar
        GetComponent<Collider>().enabled = false;
    }
}
