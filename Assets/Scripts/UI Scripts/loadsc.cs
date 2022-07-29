using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadsc : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_1");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
   
}
