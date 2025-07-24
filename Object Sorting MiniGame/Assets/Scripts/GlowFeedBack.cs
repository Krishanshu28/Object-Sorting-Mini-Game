using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlowFeedback : MonoBehaviour
{
    private Material binMat;
    private Color originalColor;
    public Color glowColor = Color.white;
    public float glowDuration = 0.3f;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        binMat = renderer.material;
        originalColor = binMat.GetColor("_EmissionColor");
    }

    public void TriggerGlow()
    {
        StartCoroutine(GlowEffect());
        StartCoroutine(PulseEffect());

    }

    IEnumerator GlowEffect()
    {
        binMat.EnableKeyword("_EMISSION");
        binMat.SetColor("_EmissionColor", glowColor);

        yield return new WaitForSeconds(glowDuration);

        binMat.SetColor("_EmissionColor", originalColor);


    }

    IEnumerator PulseEffect()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = originalScale * 1.1f;

        yield return new WaitForSeconds(glowDuration);

        transform.localScale = originalScale;
    }
}
