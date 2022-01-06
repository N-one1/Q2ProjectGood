using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudsMainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //or can use SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("TESTGameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
