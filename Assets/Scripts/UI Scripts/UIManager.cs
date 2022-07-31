using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public AudioSource audio1;
   public void PlayButton()
    {
        audio1.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }
    public void options()
    {
        audio1.Play();
    }
     public void QuitGame()
    {
        audio1.Play();
        Application.Quit();
    }
}
