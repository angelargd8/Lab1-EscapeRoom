using UnityEngine;

public class DoorHealth : MonoBehaviour
{
    [SerializeField] private int hitsToBreak = 5;
    private int hitsLeft;

    private void Awake()
    {
        hitsLeft = hitsToBreak;
    }

    public void TakeHit(int damage = 1)
    {
        hitsLeft -= damage;
        Debug.Log($"Puerta golpeada. Hits restantes: {hitsLeft}");

        if (hitsLeft <= 0)
        {
            BreakDoor();
        }
    }

    private void BreakDoor()
    {
        Destroy(gameObject);

    }
}
