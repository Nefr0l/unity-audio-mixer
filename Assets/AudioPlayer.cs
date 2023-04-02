using UnityEngine;

// Przykładowy skrypt grający dźwięki po naciśnięciu odpowiednich przycisków

public class AudioPlayer : MonoBehaviour
{
    // Zmienne do grania dźwięków
    public AudioSource musicSource;
    public AudioSource fxSource;
    public AudioClip musicClip;
    public AudioClip fxClip;
    private bool musicPlaying;
    
    // Granie muzyki
    public void PlayMusic()
    {
        switch (musicPlaying)
        {
            case false:
                musicSource.PlayOneShot(musicClip);
                musicPlaying = true;
                break;
            case true:
                musicSource.Stop();
                musicPlaying = false;
                break;
        }
    }
    
    // Granie dźwięku
    public void PlayFx()
    {
        fxSource.PlayOneShot(fxClip);
    }
}
