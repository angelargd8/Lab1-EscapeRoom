using UnityEngine;

public class TriggerPortal : MonoBehaviour
{
    public Transform PortalDestination;

    private void OnTriggerEnter(Collider other)
    {

        
        Transform root = other.transform.root;

        if (!root.CompareTag("Player")) return;

        var player = other.GetComponentInParent<CharacterController>();

        if (player == null)
        {
            Debug.Log("No encontré CharacterController en el parent de: " + other.name);
            return;
        }

        if (PortalDestination == null)
        {
            Debug.LogWarning("PortalDestination NO asignado");
            return;
        }

        Debug.Log("Portal!");

        player.enabled = false;
        player.transform.position = PortalDestination.position;
        player.transform.rotation = PortalDestination.rotation;
        player.enabled = true;
    }
}
