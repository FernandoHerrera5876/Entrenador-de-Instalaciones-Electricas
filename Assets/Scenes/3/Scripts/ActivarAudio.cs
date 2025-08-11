using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAudio : MonoBehaviour
{
    public AudioSource audioSource; // El AudioSource que se reproducirá

    private void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource no asignado en " + gameObject.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.Play(); // Reproduce el audio
                Debug.Log("Audio activado en " + gameObject.name);
            }
            else
            {
                Debug.LogError("AudioSource no asignado en " + gameObject.name);
            }
        }
    }
}
