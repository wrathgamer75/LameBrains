using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   public void PlayButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }
     public void QuitGame()
    {
        Application.Quit();
    }
}
