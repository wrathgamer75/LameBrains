using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loadsc : MonoBehaviour
{
    public void Restart()
    {
        
        SceneManager.LoadScene("restartscene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("LOADSCENE");
        Time.timeScale = 1f;
    }
   
}
