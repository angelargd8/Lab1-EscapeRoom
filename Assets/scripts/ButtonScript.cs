using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject door;   
    public Transform buttonVisual;

    public float pressDistance = 0.08f;
    public float pressSpeed = 10f;

    Vector3 startPos;
    Vector3 pressedPos;
    bool pressed;

    void Start()
    {
        if (buttonVisual == null) buttonVisual = transform;

        startPos = buttonVisual.localPosition;
        pressedPos = startPos + Vector3.down * pressDistance;
    }


    void OnTriggerEnter(Collider other)
    {
        if (pressed) return;
        if (!other.CompareTag("Player")) return;

        pressed = true;

        if (door != null)
        {
            
            var doorController = door.GetComponent<DoorController>();
            if (doorController != null)
            {
                doorController.OpenDoor();
            }
            else
            {
                Debug.LogWarning("Door GameObject no tiene DoorController component");
            }
        }
    }

    void Update()
    {
        Vector3 target = pressed ? pressedPos : startPos;
        buttonVisual.localPosition = Vector3.Lerp(buttonVisual.localPosition,  target, Time.deltaTime * pressSpeed);
    }
}
