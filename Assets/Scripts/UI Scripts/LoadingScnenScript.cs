using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScnenScript : MonoBehaviour
{
    public Animator anim;
    private float timedelay = 2f;
    private void Start()
    {
        anim.SetTrigger("load");
    }
    private void Update()
    {
        timedelay -= Time.deltaTime;
        if(timedelay <= 0)
        {    
            SceneManager.LoadScene("LOADSCENE");
        }
    }
}