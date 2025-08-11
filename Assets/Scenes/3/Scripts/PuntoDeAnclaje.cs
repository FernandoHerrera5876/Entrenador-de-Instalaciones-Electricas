using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDeAnclaje : MonoBehaviour
{
   public Transform objetoAAnclar; // Objeto que será anclado al punto de anclaje
    public float distanciaDeAnclaje = 5f; // Distancia a la cual el objeto se anclará
    public float fuerzaDeAtraccion = 10f; // Fuerza con la que el punto de anclaje atraerá el objeto
    private Vector3 posicionOriginal; // Almacena la posición original del objeto antes de anclarlo
    private Quaternion rotacionOriginal; // Almacena la rotación original del objeto antes de anclarlo
    private bool estaAnclado = false; // Estado actual del objeto (anclado o no)

    void Start()
    {
        if (objetoAAnclar != null)
        {
            // Almacena la posición y rotación originales del objeto
            posicionOriginal = objetoAAnclar.position;
            rotacionOriginal = objetoAAnclar.rotation;
        }
        else
        {
            Debug.LogError("Objeto a anclar no asignado en " + gameObject.name);
        }
    }

    void Update()
    {
        if (objetoAAnclar != null)
        {
            float distancia = Vector3.Distance(transform.position, objetoAAnclar.position);

            // Ancla el objeto si está dentro de la distancia de anclaje y no está anclado
            if (distancia <= distanciaDeAnclaje && !estaAnclado)
            {
                AnclarObjeto();
            }
            // Desancla el objeto si se mueve y está anclado
            else if (distancia > distanciaDeAnclaje && estaAnclado)
            {
                DesanclarObjeto();
            }

            // Atrae el objeto si está dentro de la distancia de atracción y no está anclado
            if (distancia <= distanciaDeAnclaje && !estaAnclado)
            {
                Vector3 direccionDeAtraccion = (transform.position - objetoAAnclar.position).normalized;
                objetoAAnclar.position += direccionDeAtraccion * fuerzaDeAtraccion * Time.deltaTime;
            }
        }
    }

    // Método para anclar el objeto en el punto de anclaje
    public void AnclarObjeto()
    {
        if (objetoAAnclar != null)
        {
            objetoAAnclar.position = transform.position;
            objetoAAnclar.rotation = transform.rotation;
            estaAnclado = true;
            Debug.Log("Objeto " + objetoAAnclar.name + " anclado en " + gameObject.name);
        }
    }

    // Método para desanclar el objeto y devolverlo a su posición original
    public void DesanclarObjeto()
    {
        if (objetoAAnclar != null)
        {
            objetoAAnclar.position = posicionOriginal;
            objetoAAnclar.rotation = rotacionOriginal;
            estaAnclado = false;
            Debug.Log("Objeto " + objetoAAnclar.name + " desanclado y devuelto a su posición original.");
        }
    }
}
