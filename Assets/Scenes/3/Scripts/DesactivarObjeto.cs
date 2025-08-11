using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarObjeto : MonoBehaviour
{
    public GameObject objetoADesactivar; // El GameObject que deseas desactivar
    public float tiempoDesactivado = 5f; // Tiempo durante el cual el objeto permanecerá desactivado

    private void Start()
    {
        if (objetoADesactivar == null)
        {
            Debug.LogError("GameObject a desactivar no asignado en " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            if (objetoADesactivar != null)
            {
                StartCoroutine(DesactivarYReactivarObjeto());
            }
            else
            {
                Debug.LogError("GameObject a desactivar no asignado en " + gameObject.name);
            }
        }
    }

    private IEnumerator DesactivarYReactivarObjeto()
    {
        Debug.Log("GameObject " + objetoADesactivar.name + " desactivado.");
        objetoADesactivar.SetActive(false); // Desactiva el GameObject
        yield return new WaitForSeconds(tiempoDesactivado); // Espera el tiempo especificado
        objetoADesactivar.SetActive(true); // Reactiva el GameObject
        Debug.Log("GameObject " + objetoADesactivar.name + " reactivado.");
    }
}
