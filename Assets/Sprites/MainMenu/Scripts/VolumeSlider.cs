using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    float savedVolume;

    private void Start()
    {
        savedVolume = PlayerPrefs.GetFloat("volume", 1.0f);
        volumeSlider.value = savedVolume;
        AudioManager.Instance.BackgroundMusic(savedVolume);
    }

    public void Volume()
    {
        AudioManager.Instance.BackgroundMusic(volumeSlider.value);
    }
}
