using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    public GameObject caja; // El objeto que deseas instanciar
    public Transform puntoDeAparicion; // El punto donde deseas que aparezca el objeto
    public float tiempoParaEliminar = 5f; // Tiempo después del cual se eliminará el Animator

    private void Start()
    {
        // Puedes inicializar cualquier cosa que necesites aquí
    }

    private void Update()
    {
        // Puedes manejar cualquier lógica de actualización aquí
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto colisionado tiene el nombre "CajaB"
        if (other.gameObject.name == "CajaB")
        {
            // Verifica si el punto de aparición está asignado
            if (puntoDeAparicion != null)
            {
                // Instancia el objeto "caja" en la posición del punto de aparición
                GameObject objetoInstanciado = Instantiate(caja, puntoDeAparicion.position, puntoDeAparicion.rotation);

                // Inicia la coroutine para eliminar el Animator después de un tiempo
                Animator animadorAEliminar = objetoInstanciado.GetComponent<Animator>();
                if (animadorAEliminar != null)
                {
                    StartCoroutine(EliminarAnimatorDespuesDeTiempo(animadorAEliminar, tiempoParaEliminar));
                }
                else
                {
                    Debug.LogError("Animator no encontrado en el objeto instanciado " + objetoInstanciado.name);
                }
            }
            else
            {
                Debug.LogError("Punto de aparición no asignado en " + gameObject.name);
            }
        }
    }

    private IEnumerator EliminarAnimatorDespuesDeTiempo(Animator animador, float tiempo)
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(tiempo);

        // Destruye el Animator
        if (animador != null)
        {
            Destroy(animador);
            Debug.Log("Animator eliminado después de " + tiempo + " segundos en " + animador.gameObject.name);
        }
    }
}
