using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnclarAlPunto : MonoBehaviour
{
    public Transform puntoDeAnclaje; // Punto de anclaje al que el objeto se debe anclar
    public GameObject figuraGuia; // Figura que se activará al inicio y se desactivará cuando el objeto se ancle
    public float distanciaDeAnclaje = 5f; // Distancia a la cual el objeto se anclará
    public float fuerzaDeAtraccion = 10f; // Fuerza con la que el punto de anclaje atraerá el objeto
    private Vector3 posicionOriginal; // Almacena la posición original del objeto antes de anclarlo
    private Quaternion rotacionOriginal; // Almacena la rotación original del objeto antes de anclarlo
    private Vector3 escalaOriginal; // Almacena la escala original del objeto antes de anclarlo
    private bool estaAnclado = false; // Estado actual del objeto (anclado o no)
    private Rigidbody rb; // Referencia al componente Rigidbody

    void Start()
    {
        if (puntoDeAnclaje != null)
        {
            // Almacena la posición, rotación y escala originales del objeto
            posicionOriginal = transform.position;
            rotacionOriginal = transform.rotation;
            escalaOriginal = transform.localScale;

            // Obtiene el componente Rigidbody
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody no asignado en " + gameObject.name);
            }
        }
        else
        {
            Debug.LogError("Punto de anclaje no asignado en " + gameObject.name);
        }

        if (figuraGuia != null)
        {
            figuraGuia.SetActive(true); // Activa la figura guía al inicio
        }
        else
        {
            Debug.LogError("Figura guía no asignada en " + gameObject.name);
        }
    }

    void Update()
    {
        if (puntoDeAnclaje != null && rb != null)
        {
            float distancia = Vector3.Distance(puntoDeAnclaje.position, transform.position);

            // Atrae el objeto si está dentro de la distancia de atracción y no está anclado
            if (distancia <= distanciaDeAnclaje && !estaAnclado)
            {
                Vector3 direccionDeAtraccion = (puntoDeAnclaje.position - transform.position).normalized;
                rb.MovePosition(transform.position + direccionDeAtraccion * fuerzaDeAtraccion * Time.deltaTime);
            }

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
        }
    }

    // Método para anclar el objeto en el punto de anclaje
    public void AnclarObjeto()
    {
        if (puntoDeAnclaje != null)
        {
            transform.position = puntoDeAnclaje.position;
            transform.rotation = puntoDeAnclaje.rotation;
            transform.localScale = puntoDeAnclaje.localScale;
            rb.isKinematic = true; // Desactiva la gravedad y las fuerzas del Rigidbody
            estaAnclado = true;
            if (figuraGuia != null)
            {
                figuraGuia.SetActive(false); // Desactiva la figura guía cuando el objeto se ancla
            }
            Debug.Log("Objeto " + gameObject.name + " anclado en " + puntoDeAnclaje.name);
        }
    }

    // Método para desanclar el objeto y devolverlo a su transformación original
    public void DesanclarObjeto()
    {
        transform.position = posicionOriginal;
        transform.rotation = rotacionOriginal;
        transform.localScale = escalaOriginal;
        rb.isKinematic = false; // Reactiva la gravedad y las fuerzas del Rigidbody
        estaAnclado = false;
        if (figuraGuia != null)
        {
            figuraGuia.SetActive(true); // Activa la figura guía cuando el objeto se desancla
        }
        Debug.Log("Objeto " + gameObject.name + " desanclado y devuelto a su transformación original.");
    }
}
