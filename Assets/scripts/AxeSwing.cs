using System.Collections;
using UnityEngine;

public class AxeSwing : MonoBehaviour
{
    [Header("Referencia")]
    public Transform axeTransform; // si es null usa este transform

    [Header("Swing settings")]
    public float duration = 0.12f;
    public float returnDuration = 0.10f;

    public Vector3 localPosOffset = new Vector3(0.12f, -0.04f, 0.00f);
    public Vector3 localRotOffset = new Vector3(0f, 35f, 25f);

    // maximo local para que no se vaya lejos
    public float maxLocalMove = 0.25f;

    private Vector3 basePos;
    private Quaternion baseRot;
    private bool isSwinging;

    private void Awake()
    {
        if (axeTransform == null) axeTransform = transform;
    }

    public void PlaySwing()
    {
        if (isSwinging) return;

        // Captura base cada vez que se ataca
        basePos = axeTransform.localPosition;
        baseRot = axeTransform.localRotation;

        StartCoroutine(SwingRoutine());
    }

    private IEnumerator SwingRoutine()
    {
        isSwinging = true;

        Vector3 targetPos = ClampToBase(basePos + localPosOffset);
        Quaternion targetRot = baseRot * Quaternion.Euler(localRotOffset);

        // ir al golpe
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float k = t / duration;

            axeTransform.localPosition = Vector3.Lerp(basePos, targetPos, k);
            axeTransform.localRotation = Quaternion.Slerp(baseRot, targetRot, k);

            yield return null;
        }

        // regresar
        t = 0f;
        while (t < returnDuration)
        {
            t += Time.deltaTime;
            float k = t / returnDuration;

            axeTransform.localPosition = Vector3.Lerp(targetPos, basePos, k);
            axeTransform.localRotation = Quaternion.Slerp(targetRot, baseRot, k);

            yield return null;
        }

        // retorno
        axeTransform.localPosition = basePos;
        axeTransform.localRotation = baseRot;

        isSwinging = false;
    }

    private Vector3 ClampToBase(Vector3 pos)
    {
        Vector3 delta = pos - basePos;
        if (delta.magnitude > maxLocalMove)
            delta = delta.normalized * maxLocalMove;

        return basePos + delta;
    }
}
