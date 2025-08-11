using UnityEngine;
using UnityEngine.Video;

public class AudioVideoController : MonoBehaviour
{
    public VideoPlayer[] videoPlayers;  // Arreglo de VideoPlayers
    public AudioSource[] backgroundMusics; // Arreglo de AudioSources

    void Start()
    {
        // Inicia la música de fondo para cada video
        foreach (AudioSource audio in backgroundMusics)
        {
            audio.Play();
        }
    }

    void Update()
    {
        for (int i = 0; i < videoPlayers.Length; i++)
        {
            // Pausar música cuando el video esté reproduciéndose
            if (videoPlayers[i].isPlaying && backgroundMusics[i].isPlaying)
            {
                backgroundMusics[i].Pause();
            }

            // Reanudar música cuando el video esté pausado
            if (!videoPlayers[i].isPlaying && !backgroundMusics[i].isPlaying)
            {
                backgroundMusics[i].Play();
            }
        }
    }

    // Métodos para controlar la reproducción de los videos
    public void PlayVideo(int index)
    {
        if (index >= 0 && index < videoPlayers.Length)
            videoPlayers[index].Play();
    }

    public void PauseVideo(int index)
    {
        if (index >= 0 && index < videoPlayers.Length)
            videoPlayers[index].Pause();
    }
}
