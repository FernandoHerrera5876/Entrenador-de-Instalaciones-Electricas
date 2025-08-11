using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boleano : MonoBehaviour
{
    public List<GameObject> objectParts; // Lista de partes del objeto
    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;

        // Desactivar todas las partes del objeto al inicio
        foreach (var part in objectParts)
        {
            part.SetActive(false);
        }

        StartCoroutine(GlitchRoutine());
    }

    private IEnumerator GlitchRoutine()
    {
        while (true)
        {
            foreach (var part in objectParts)
            {
                // Activar parte
                part.SetActive(true);

                // Aplicar efecto de glitch a la parte
                material = part.GetComponent<Renderer>().material;
                material.SetFloat("_GlitchStrength", 0.0f);
                material.SetFloat("_ScanlineOffset", 0.0f);
                yield return new WaitForSeconds(0.25f);

                material.SetFloat("_GlitchStrength", 0.15f);
                material.SetFloat("_ScanlineOffset", 0.5f);
                yield return new WaitForSeconds(0.25f);

                material.SetFloat("_GlitchStrength", 0.0f);
                material.SetFloat("_ScanlineOffset", 0.0f);
                yield return new WaitForSeconds(0.5f);

                material.SetFloat("_GlitchStrength", 0.1f);
                material.SetFloat("_ScanlineOffset", 0.5f);
                yield return new WaitForSeconds(0.1f);

                material.SetFloat("_GlitchStrength", 0.0f);
                material.SetFloat("_ScanlineOffset", 0.0f);
                yield return new WaitForSeconds(0.1f);

                material.SetFloat("_GlitchStrength", 0.05f);
                material.SetFloat("_ScanlineOffset", 0.5f);
                yield return new WaitForSeconds(0.1f);

                material.SetFloat("_GlitchStrength", 0.0f);
                material.SetFloat("_ScanlineOffset", 0.0f);
                yield return new WaitForSeconds(0.4f);

                material.SetFloat("_GlitchStrength", 0.1f);
                material.SetFloat("_ScanlineOffset", 0.5f);
                yield return new WaitForSeconds(0.3f);

                // Desactivar parte
                part.SetActive(false);
            }
        }
    }
}