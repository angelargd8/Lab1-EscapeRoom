using UnityEngine;

public class AxeHit : MonoBehaviour
{
    [SerializeField] private int damagePerHit = 1;
    

    // para evitar que cuente muchos golpes en un solo choque
    [SerializeField] private float hitCooldown = 0.3f;
    private float lastHitTime;


    public bool isAttacking;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger con: " + other.name);

        if (!isAttacking) return;
        if (Time.time - lastHitTime < hitCooldown) return;

        // buscar DoorHealth en el mismo y si no en el padre
        DoorHealth door = other.GetComponent<DoorHealth>();
        if (door == null) door = other.GetComponentInParent<DoorHealth>();

        if (door != null)
        {
            Debug.Log("Golpe a puerta: " + door.name);
            
            door.TakeHit(damagePerHit);
            lastHitTime = Time.time;
        }
        else
        {
            Debug.Log("No encontro DoorHealth en " + other.name + " ni en sus padres");
        }
    }

}

