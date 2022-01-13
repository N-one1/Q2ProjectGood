using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudsonGAMEOVER : MonoBehaviour
{
    public void PlayGame()
    {
        //or can use SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("MainScene");
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu UI");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
