using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public AudioSource musicSource;

    float savedVolume;

    public void Awake()
    {
        Instance = this;
        savedVolume = PlayerPrefs.GetFloat("volume", 1.0f);
    }

    public void BackgroundMusic(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("volume", musicSource.volume);
        PlayerPrefs.Save();
    }
}
