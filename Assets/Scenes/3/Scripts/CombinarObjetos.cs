using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinarObjetos : MonoBehaviour
{
    public int numeroObjetosParaCombinar = 3; // Número de objetos necesarios para combinar
    private List<GameObject> objetosColisionados = new List<GameObject>(); // Lista para almacenar los objetos colisionados

    private void OnTriggerEnter(Collider other)
    {
        // Añadir el objeto colisionado a la lista
        objetosColisionados.Add(other.gameObject);

        // Verifica si el número de objetos colisionados alcanza el número requerido para combinar
        if (objetosColisionados.Count >= numeroObjetosParaCombinar)
        {
            Combinar();
        }
    }

    private void Combinar()
    {
        // Crear un nuevo objeto para representar la combinación de los objetos colisionados
        GameObject objetoCombinado = new GameObject("ObjetoCombinado");

        // Calcular la posición media de los objetos colisionados
        Vector3 posicionMedia = Vector3.zero;
        foreach (GameObject obj in objetosColisionados)
        {
            posicionMedia += obj.transform.position;
        }
        posicionMedia /= objetosColisionados.Count;

        // Configurar la posición y rotación del objeto combinado
        objetoCombinado.transform.position = posicionMedia;
        objetoCombinado.transform.rotation = Quaternion.identity;

        // Combinar los colliders de los objetos colisionados en el objeto combinado
        foreach (GameObject obj in objetosColisionados)
        {
            Collider collider = obj.GetComponent<Collider>();
            if (collider != null)
            {
                Collider nuevoCollider = objetoCombinado.AddComponent(collider.GetType()) as Collider;
                if (nuevoCollider != null)
                {
                    nuevoCollider.isTrigger = collider.isTrigger;
                }
            }

            // Destruir el objeto original
            Destroy(obj);
        }

        // Limpia la lista de objetos colisionados
        objetosColisionados.Clear();
    }
}
