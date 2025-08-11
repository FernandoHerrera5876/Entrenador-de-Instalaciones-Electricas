using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class FadeTeleportationProvider : TeleportationProvider
{
    public Image fadeImage; // Imagen negra UI en el centro de la pantalla
    public float fadeDuration = 0.5f;

    private bool isFading = false;

    public override bool QueueTeleportRequest(TeleportRequest teleportRequest)
    {
        if (isFading)
            return false;

        StartCoroutine(FadeAndTeleport(teleportRequest));
        return true; // Le decimos que nosotros manejaremos el teleport
    }

    private IEnumerator FadeAndTeleport(TeleportRequest request)
    {
        isFading = true;

        // FADE OUT
        yield return StartCoroutine(Fade(0, 1));

        // Hacemos el teleport después del fade
        base.QueueTeleportRequest(request);

        // FADE IN
        yield return StartCoroutine(Fade(1, 0));

        isFading = false;
    }

    private IEnumerator Fade(float start, float end)
    {
        float elapsed = 0f;
        Color c = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(start, end, elapsed / fadeDuration);
            fadeImage.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(c.r, c.g, c.b, end);
    }
}