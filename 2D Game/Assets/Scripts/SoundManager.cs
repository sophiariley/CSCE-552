using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("masterVolume"))
        {
            PlayerPrefs.SetFloat("masterVolume", (float)0.5);
            Load();
        } else
        {
            Load();
        }
    }

    public void ChangeVolume() 
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }

    private void Save() 
    {
        PlayerPrefs.SetFloat("masterVolume", volumeSlider.value);
    }
}
