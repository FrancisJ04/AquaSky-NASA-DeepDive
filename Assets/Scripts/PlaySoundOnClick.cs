using UnityEngine;

public class PlayPauseOnClick : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (audioSource == null) return;

        if (!audioSource.isPlaying)
        {
            // Si está detenido o pausado → reproducir
            audioSource.Play();
        }
        else
        {
            // Si está reproduciendo → pausar
            audioSource.Pause();
        }
    }
}