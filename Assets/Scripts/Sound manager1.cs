using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Soundmanager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
//    private Slider volumeSlider;
//   [SerializeField] Slider SFXSlider;
    private bool muted = false;

    public static Soundmanager instance;


    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("dont destroy");
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            print("do destroy");
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        /*
        if (PlayerPrefs.HasKey("volumeSlider"))
        {
            Load();
        }
        else
        {

        }
        */
    }
    public void SetMusicVolume( float vol )
    {
        myMixer.SetFloat("music", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("volumeSlider", vol);
        print("change music vol to " + vol );
    }

    public void SetSFXVolume(float val)
    {
        myMixer.SetFloat("SFX", Mathf.Log10(val) * 20);
        PlayerPrefs.SetFloat("SFXSVolume", val);
        print("change sfx vol " + val);
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

        Save();
    }


    
    private void Load()
    {

        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {

        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
