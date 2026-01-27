using UnityEngine;

public class RevealPortalOnMove : MonoBehaviour
{
    public GameObject portal;
    public float moveDistance = 1.0f;
    public GameObject fridgeDoor;

    Vector3 startPos;
    bool revealed;

    void Start()
    {
        startPos = transform.position;
        if (portal) portal.SetActive(false);
    }

    void Update()
    {
        if (revealed || portal == null) return;

        float d = Vector3.Distance(transform.position, startPos);
        if (d >= moveDistance)
        {
            if (fridgeDoor) fridgeDoor.SetActive(false);
            revealed = true;
            portal.SetActive(true);
        }
    }
}
