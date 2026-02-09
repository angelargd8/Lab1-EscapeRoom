using UnityEngine;

public class HazardKill : MonoBehaviour
{
    [SerializeField] AudioClip FloorSFX;

    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {

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

        AudioManager.Instance.PlaySFX(FloorSFX);

        player.enabled = false;
        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;
        player.enabled = true;
    }
}
