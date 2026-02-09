using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float disableDelay = 0f;

    public void OpenDoor()
    {
        Invoke(nameof(DisableDoor), disableDelay);
    }

        void DisableDoor()
    {
        gameObject.SetActive(false);
    }
}
