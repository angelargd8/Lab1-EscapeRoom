using UnityEngine;

public class DoorByKey : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!PlayerInventory.hasKey) return;

        // Consumir llave 
        PlayerInventory.ConsumeKey();

        // Destruir puerta
        Destroy(gameObject);
    }
}
