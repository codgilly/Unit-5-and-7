using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class Startscreen : MonoBehaviour
{


    public float TimeScale;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoNextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GoBackScene()
    {
        SceneManager.LoadScene(0);
    }

    public void StartSlowMotion()
    {
        Time.timeScale = 0;

    }

    public void StopSlowMotion()
    {
        Time.timeScale = 1;
    }
}
