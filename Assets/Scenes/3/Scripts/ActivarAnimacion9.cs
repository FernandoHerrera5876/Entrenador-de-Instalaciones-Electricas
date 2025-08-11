using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAnimacion9 : MonoBehaviour
{
    public Animator animacion1; // Asegúrate de asignar el primer Animator en el Inspector de Unity
    public string nombreAnimacion1 = "compresora3"; // Nombre de la primera animación a reproducir
    public string nombreAnimacion2 = "Pieza2"; // Nombre de la segunda animación a reproducir
    public float tiempoDesactivacion = 10f; // Tiempo después del cual se desactivan las animaciones
    public SpawnPanel scriptSpawn; // Referencia al script AparicionObjeto

    private Animator animacion2; // Animator del objeto instanciado
    private bool puedeActivarAnimaciones = true; // Flag para controlar la activación de animaciones

    private void Start()
    {
        if (animacion1 != null)
        {
            animacion1.enabled = false; // Desactiva el primer Animator al inicio
            Debug.Log("Primer Animator desactivado al inicio.");
        }
        else
        {
            Debug.LogError("Primer Animator no asignado en " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider tiene el tag "Player" y si se pueden activar las animaciones
        if (other.CompareTag("Player") && puedeActivarAnimaciones)
        {
            // Obtiene la referencia al objeto instanciado y su Animator
            GameObject objetoInstanciado = scriptSpawn.ObtenerObjetoInstanciado();
            if (objetoInstanciado != null)
            {
                animacion2 = objetoInstanciado.GetComponent<Animator>();
                if (animacion2 != null)
                {
                    animacion2.enabled = false; // Asegura que el Animator del objeto instanciado esté desactivado al inicio
                }
            }

            if (animacion1 != null && animacion2 != null)
            {
                Debug.Log("Player ha colisionado con " + gameObject.name);
                animacion1.enabled = true; // Activa el primer Animator
                animacion2.enabled = true; // Activa el segundo Animator
                animacion1.Play(nombreAnimacion1, 0, 0f); // Reproduce la primera animación desde el inicio
                animacion2.Play(nombreAnimacion2, 0, 0f); // Reproduce la segunda animación desde el inicio
                Debug.Log("Animación '" + nombreAnimacion1 + "' reproducida en " + gameObject.name);
                Debug.Log("Animación '" + nombreAnimacion2 + "' reproducida en " + objetoInstanciado.name);
                StartCoroutine(DesactivarAnimacionesDespuesDeTiempo(tiempoDesactivacion)); // Inicia la coroutine para desactivar las animaciones
                puedeActivarAnimaciones = false; // Desactiva la posibilidad de activar animaciones
            }
            else
            {
                if (animacion1 == null)
                {
                    Debug.LogError("Primer Animator no asignado en " + gameObject.name);
                }
                if (animacion2 == null)
                {
                    Debug.LogError("Segundo Animator no asignado en " + objetoInstanciado.name);
                }
            }
        }
    }

    // Coroutine para desactivar las animaciones después de un tiempo
    private IEnumerator DesactivarAnimacionesDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Espera el tiempo especificado
        if (animacion1 != null)
        {
            animacion1.enabled = false; // Desactiva el primer Animator
            Debug.Log("Primer Animator desactivado después de " + tiempo + " segundos en " + gameObject.name);
        }
        if (animacion2 != null)
        {
            animacion2.enabled = false; // Desactiva el segundo Animator
            Debug.Log("Segundo Animator desactivado después de " + tiempo + " segundos en " + animacion2.gameObject.name);
        }

        puedeActivarAnimaciones = true; // Permite volver a activar las animaciones
    }
}
