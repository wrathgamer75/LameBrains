using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbactivating : MonoBehaviour
{
   public IEnumerator activatezombie(float timer,GameObject zombie)
    {
        Debug.Log("Before Return");
        yield return new WaitForSeconds(timer);
        Debug.Log("After Return");
        zombie.SetActive(true);
    }
    public void dumbtesting(float time, GameObject zombie)
    {
        StartCoroutine(activatezombie(time, zombie));
    }
   
}
