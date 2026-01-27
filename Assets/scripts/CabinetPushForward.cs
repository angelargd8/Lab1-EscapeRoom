using UnityEngine;

// este script esta muy chatoso, porque no me salia jaja

public class CabinetPushForward : MonoBehaviour
{
    [Header("Push Settings")]
    public float pushForce = 6f;
    public KeyCode pushKey = KeyCode.E;
    public Transform forwardReference; // PushDirection 

    [Header("Debug")]
    public bool verboseLogs = true;

    private Rigidbody cabinetRb;  
    private bool playerInRange;
    private Transform player;

    void Awake()
    {
        // el rigid body del cabinet
        cabinetRb = GetComponentInParent<Rigidbody>();

        if (verboseLogs)
        {
            Debug.Log($"[CabinetPushForward] Awake en '{gameObject.name}'. Parent RB = {(cabinetRb ? cabinetRb.gameObject.name : "NULL")}", this);

            if (cabinetRb != null)
            {
                Debug.Log($"[CabinetPushForward] RB settings: isKinematic={cabinetRb.isKinematic}, useGravity={cabinetRb.useGravity}, constraints={cabinetRb.constraints}", this);
            }
        }

        if (cabinetRb == null)
            Debug.LogError("[CabinetPushForward] No encontré Rigidbody en el padre (Cabinet_3).", this);
    }

    void Update()
    {
        // Log al presionar E
        if (Input.GetKeyDown(pushKey) && verboseLogs)
        {
            Debug.Log($"[CabinetPushForward] E presionada. inRange={playerInRange}, player={(player ? player.name : "null")}, rb={(cabinetRb ? "OK" : "NULL")}", this);
        }

        if (!playerInRange) return;
        if (cabinetRb == null) return;

        if (Input.GetKeyDown(pushKey))
        {
            Vector3 dir = (forwardReference != null) ? forwardReference.forward : cabinetRb.transform.forward;
            dir.y = 0f;
            dir.Normalize();

            // Empujar
            cabinetRb.AddForce(dir * pushForce, ForceMode.Impulse);

            if (verboseLogs)
            {
                Debug.Log($"[CabinetPushForward] EMPUJE aplicado. dir={dir}, pushForce={pushForce}", this);
                Debug.Log($"[CabinetPushForward] Vel después: {cabinetRb.linearVelocity}", this);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (verboseLogs)
            Debug.Log($"[CabinetPushForward] Trigger ENTER con '{other.name}' tag='{other.tag}' root='{other.transform.root.name}'", this);

        // Si el collider es hijo del player, busca el tag en el padre
        Transform t = other.transform;
        while (t != null && !t.CompareTag("Player"))
            t = t.parent;

        if (t == null)
        {
            if (verboseLogs) Debug.Log("[CabinetPushForward] -> No era Player (ni padre con tag Player).", this);
            return;
        }

        player = t;
        playerInRange = true;

        if (verboseLogs) Debug.Log($"[CabinetPushForward] -> Player detectado: {player.name}. inRange=true", this);
    }

    void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        while (t != null && !t.CompareTag("Player"))
            t = t.parent;

        if (t == null) return;

        if (player != null && t == player)
        {
            playerInRange = false;
            player = null;
            if (verboseLogs) Debug.Log("[CabinetPushForward] -> Player salió. inRange=false", this);
        }
    }
}
