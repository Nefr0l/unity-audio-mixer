using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

    /* Skrypt zarządzający mixerami audio

    Aby skrypt działał musisz dodać ExposedParameter do każdej z grup mixera oraz zmienić nazwę parametrów
    1. Zaznacz grupę mixera audio w zakładce "Audio mixer"
    2. Kliknij ppm na napis "Volume" w zakładce "Inspector i wybierz opcję "Expose parameter"
    3. W zakładce "Audio mixer" kliknij w prawym górnym rogu na "Exposed parameters" i zmień nazwę każdego klikając ppm i wybierając "rename"
    */

public class Manager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider fxSlider;
    
    private float musicVolume;
    private float fxVolume;
    public AudioMixer mixer;

    void Start()
    {
        if (PlayerPrefs.HasKey("fxVolume")) { ReadData(); }
    }

    private void SaveData()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("fxVolume", fxVolume);
    }

    private void ReadData()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        fxVolume = PlayerPrefs.GetFloat("fxVolume");

        musicSlider.value = musicVolume;
        fxSlider.value = fxVolume;
    }

    public void SliderValueChanged(string volumeType) // music, fx
    {
        switch (volumeType)
        {
            case "music":
                musicVolume = musicSlider.value;
                mixer.SetFloat("musicVolume", musicVolume);
                print("Głośność muzyki: " + musicVolume + "db");
                break;
            case "fx":
                fxVolume = fxSlider.value;
                mixer.SetFloat("fxVolume", fxVolume);
                print("Głośność dźwięków: " + fxVolume + "db");
                break;
        }
        SaveData();
    }
}