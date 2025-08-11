using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class VideoSelection : MonoBehaviour
{
    public VideoPlayer videoPlayer; // VideoPlayer de este objeto
    public AudioSource backgroundMusic; // Música de fondo

    private bool isSelected = false; // Estado de si este video ha sido seleccionado

    void Start()
    {
        // Asegúrate de que no se reproduzca al principio si no lo has seleccionado
        videoPlayer.Pause();
    }

    // Asignado al evento OnSelectEntered (cuando el video es seleccionado)
    public void OnSelectEntered()
    {
        // Si el video está pausado, se reproduce
        if (videoPlayer.isPaused)
        {
            PlayVideo();
        }
        else // Si el video ya se está reproduciendo, se pausa
        {
            PauseVideo();
        }
    }

    // Reproduce el video y pausa la música de fondo
    void PlayVideo()
    {
        backgroundMusic.Pause(); // Pausa la música de fondo
        videoPlayer.Play(); // Reproduce el video
    }

    // Pausa el video y reanuda la música de fondo
    void PauseVideo()
    {
        videoPlayer.Pause(); // Pausa el video
        backgroundMusic.Play(); // Reanuda la música de fondo
    }
}
