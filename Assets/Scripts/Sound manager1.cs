using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    private bool muted = false;

    AudioSource audioSource;
    public AudioClip ButtonPress;
    public AudioClip Song;

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            load();
        }
        else
        {
            load();
        }

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            load();
        }

        else
        {
            load();
        }


        audioSource = GetComponent<AudioSource>();
        print("audio source=" + audioSource);
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
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }
    
    public void ButtonSoundEF()
    {
        audioSource.PlayOneShot(ButtonPress);
    }
    
    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
