using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAdditional : MonoBehaviour
{
    public GameObject lights;
    public int health = 100;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.H)) ;
        //{
        //    lights.SetActive(false);
        //}
        if (health == 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy" && speed>=20)
        {
            health--;
        }

    }
}
