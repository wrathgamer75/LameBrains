using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    private HealthBarScript Health;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private void Awake()
    {
        if (Health == null)
        {
            Health = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        SetMaxhealth();
    }
    public void SetMaxhealth()
    {
    
        slider.value = slider.maxValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void updatehealthbarcolor()
    {    
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
 
}