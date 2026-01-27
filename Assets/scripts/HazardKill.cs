using UnityEngine;

public class HazardKill : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hazard TRIGGER ENTER con: " + other.name + " | tag: " + other.tag);

        var player = other.GetComponentInParent<CharacterController>();

        if (other.GetComponentInParent<CharacterController>() == null) return;

        if (player == null)
        {
            Debug.Log("No encontro CharacterController en el parent de: " + other.name);
            return;
        }

        if (respawnPoint == null)
        {
            Debug.LogWarning("RespawnPoint no asignado");
            return;
        }

        Debug.Log("Respawn");

        player.enabled = false;
        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;
        player.enabled = true;
    }
}
