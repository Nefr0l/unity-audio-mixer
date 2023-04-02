using UnityEngine;

    // Skrypt odpowiada za granie dźwięku lub muzyki przy naciśnięciu danego przycisku

public class AudioPlayer : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource fxSource;
    public AudioClip musicClip;
    public AudioClip fxClip;

    public void PlayMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
        else
            musicSource.PlayOneShot(musicClip);
    }

    public void PlaySound()
    {
        fxSource.PlayOneShot(fxClip);
    }
}