using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeTeleport : MonoBehaviour
{
    public Transform xrOrigin;          // XR Origin a mover
    public Transform teleportTarget;    // Posición destino
    public Image fadeImage;             // Imagen negra del Canvas
    public float fadeDuration = 1f;     // Duración del fundido

    void Start()
    {
        // Asegura que la imagen comience transparente (alpha 0)
        if (fadeImage != null)
            fadeImage.color = new Color(0, 0, 0, 0);
    }

    public void StartTeleport()
    {
        StartCoroutine(FadeAndTeleport());
    }

    IEnumerator FadeAndTeleport()
    {
        // FADE OUT
        yield return StartCoroutine(Fade(0f, 1f));

        // TELETRANSPORTE
        if (xrOrigin != null && teleportTarget != null)
            xrOrigin.position = teleportTarget.position;

        // FADE IN
        yield return StartCoroutine(Fade(1f, 0f));
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;

        if (fadeImage == null)
            yield break;

        Color c = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            fadeImage.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }

        // Asegura que al final tenga el valor exacto
        fadeImage.color = new Color(c.r, c.g, c.b, endAlpha);
    }
}