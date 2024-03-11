using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Soundmanager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider SFXSlider;
    private bool muted = false;



    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("volumeSlider"))
        {
            load();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volumeSlider", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXSVolume", volume);
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        save();
    }


    
    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumeSlider");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSVolume");
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void save()
    {

        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
