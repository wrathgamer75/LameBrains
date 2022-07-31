using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioAccessScript : MonoBehaviour
{
    public Slider volumeslider;

   public void volume()
    {
        AudioListener.volume=volumeslider.value;
    }
}
