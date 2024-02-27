using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscreen : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
