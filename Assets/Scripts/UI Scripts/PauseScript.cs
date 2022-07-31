using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
    public GameObject InGameUI;
    public GameObject fade;
    public AudioSource aud;
    public AudioSource decay;

    private void Start()
    {
        InGameUI.SetActive(true);
        pausemenuUI.SetActive(false);
        fade.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        aud.Play();
        pausemenuUI.SetActive(false);
        InGameUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        decay.Play();
        pausemenuUI.SetActive(true);
        InGameUI.SetActive(false);
        fade.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void loadmenu()
    {
        aud.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("LOADSCENE");
    }
}
