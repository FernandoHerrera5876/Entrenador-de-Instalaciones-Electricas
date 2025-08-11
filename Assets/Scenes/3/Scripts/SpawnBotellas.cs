using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBotellas : MonoBehaviour
{
    public Transform puntoDeAparicion; // Punto de aparición asignado desde el Inspector
    public GameObject objetoAparecer; // Objeto que aparecerá asignado desde el Inspector

    private GameObject objetoInstanciado; // Referencia al objeto instanciado

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Verifica si el punto de aparición y el objeto están asignados
            if (puntoDeAparicion != null && objetoAparecer != null)
            {
                // Instancia el objeto en el punto de aparición y guarda la referencia
                objetoInstanciado = Instantiate(objetoAparecer, puntoDeAparicion.position, puntoDeAparicion.rotation);
                
                // Desactiva el Animator del objeto instanciado
                Animator animador = objetoInstanciado.GetComponent<Animator>();
                if (animador != null)
                {
                    animador.enabled = false;
                }
                
                Debug.Log("Objeto " + objetoAparecer.name + " apareció en " + puntoDeAparicion.position);
            }
            else
            {
                if (puntoDeAparicion == null)
                {
                    Debug.LogError("Punto de aparición no asignado en " + gameObject.name);
                }
                if (objetoAparecer == null)
                {
                    Debug.LogError("Objeto a aparecer no asignado en " + gameObject.name);
                }
            }
        }
    }

    // Método para obtener la referencia al objeto instanciado
    public GameObject ObtenerObjetoInstanciado()
    {
        return objetoInstanciado;
    }
}
