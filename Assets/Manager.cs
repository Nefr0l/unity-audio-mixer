using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

    /*
    SKRYPT ZARZĄDZAJĄCY GŁOŚNOŚCIĄ MIXERÓW AUDIO
     
    Aby skrypt działał musisz dodać ExposedParameter do każdej z grup mixera
    1. Zaznacz AudioMixerGroup jaką chcesz edytować
    2. Najedź w inspectorze na "Volumne" i kliknij prawym przyciskiem myszy
    3. Wybierz pierwszą od góry opcję

    Następnie zmień ich nazwy:
    1. Kliknij w okienku z grupami na Exposed Parameters (w prawym górnym rogu)
    2. Kliknij prawym przycsikiem myszy na każdy z kolei parametr i zmień jego nazwę (wybierając rename)
    */

public class Manager : MonoBehaviour
{
    // Elementy kontroli głośności
    public Slider musicSlider;
    public Slider fxSlider;
    
    // Zmienne dotyczące głośności
    private float musicVolume;
    private float fxVolume;
    public AudioMixer mixer;

    // Początkowa pętla
    void Start()
    {
        if (PlayerPrefs.HasKey("fxVolume")) { ReadData(); }
    }

    // Zapisywanie danych
    public void SaveData()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("fxVolume", fxVolume);
    }

    // Wczytywanie danych
    public void ReadData()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        fxVolume = PlayerPrefs.GetFloat("fxVolume");

        musicSlider.value = musicVolume;
        fxSlider.value = fxVolume;
    }

    // Funkcja robiąca to co trzeba gdy zmienisz wartość slidera
    public void SliderValueChanged(bool isMusic)
    {
        switch (isMusic)
        {
            case true:
                musicVolume = musicSlider.value;
                mixer.SetFloat("musicVolume", musicVolume);
                print("Głośność muzyki: " + musicVolume + "db");
                break;
            case false:
                fxVolume = fxSlider.value;
                mixer.SetFloat("fxVolume", fxVolume);
                print("Głośność dźwięków: " + fxVolume + "db");
                break;
        }
        SaveData();
    }
}
