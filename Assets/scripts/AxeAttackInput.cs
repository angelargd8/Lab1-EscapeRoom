using System.Collections;
using UnityEngine;

public class AxeAttackInput : MonoBehaviour
{
    [SerializeField] private AxeHit axeHit;
    [SerializeField] private AxeSwing axeSwing;
    [SerializeField] private float attackWindow = 0.25f;

    private void Awake()
    {
        if (axeHit == null) axeHit = GetComponent<AxeHit>();
        if (axeSwing == null) axeSwing = GetComponent<AxeSwing>();
    }

    private void Update()
    {
        if (!PlayerInventory.hasAxe) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            // Animación
            if (axeSwing != null) axeSwing.PlaySwing();

            // daño
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        axeHit.isAttacking = true;
        yield return new WaitForSeconds(attackWindow);
        axeHit.isAttacking = false;
    }
}
