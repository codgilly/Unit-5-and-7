using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider vSlider;


    //private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("music volume"))
        {
            Load();
            LoadSFX();
        }
        else
        { 
        }
    }

    public void ChangeSFXSlider()
    {
        float val = GetComponent<Slider>().value;
        Soundmanager.instance.SetSFXVolume(val);
        SaveSFX();
    }

    public void ChangeMSlider()
    {
        float vol = GetComponent<Slider>().value;
        Soundmanager.instance.SetMusicVolume(vol);
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("music volume", vSlider.value);
    }

    private void SaveSFX()
    {
        PlayerPrefs.SetFloat("SFX volume", sfxSlider.value);
    }

    private void Load()
    {
        vSlider.value = PlayerPrefs.GetFloat("music volume");
    }

    private void LoadSFX()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFX volume");
        print(sfxSlider.value + " sfx value");
    }

    public void Mute()
    {
        Soundmanager.instance.OnButtonPress();

    }
  
    
}
