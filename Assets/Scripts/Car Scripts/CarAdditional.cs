using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarAdditional : MonoBehaviour
{
    public GameObject lights;
    public static int health = 100;
    public int speed;
    public static int upgradecounter = 0;
    public GameObject upgrade1;
    public GameObject upgrade2;
    public GameObject upgrade3;
    public GameObject upgrade4;
    public GameObject upgrade5;
    public GameObject upgrade6;
    public GameObject upgrade7;
    public GameObject upgrade8;
    

    public TextMeshProUGUI carhptxt;
    public TextMeshProUGUI upgrades;

    // Update is called once per frame
    void Update()
    {
        carhptxt.text = health + "HP";
        upgrades.text = upgradecounter+"";

        switch(upgradecounter)
        {
            case 10:
                upgrade1.SetActive(true);
                Debug.Log("1");
                break;
            case 20:
                upgrade2.SetActive(true);
                Debug.Log("2");
                break;
            case 30:
                upgrade3.SetActive(false);
                break;
            case 40:
                upgrade4.SetActive(false);
                break;
            case 50:
                upgrade5.SetActive(false);
                break;
            case 60:
                upgrade6.SetActive(false);
                break;
            case 70:
                upgrade7.SetActive(false);
                break;
            case 80:
                upgrade8.SetActive(false);
                break;
        }

        //if (Input.GetKeyDown(KeyCode.H)) ;
        //{
        //    lights.SetActive(false);
        //}
        //if (health == 0)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //else
        //{
        //    this.gameObject.SetActive(true);
        //}
    }
    public static void carhealthdamage(int zombdmg)
    {
        health -= zombdmg;
    }
    public static void upgrade(int upgradescnt)
    {
        upgradecounter += upgradescnt;
    }

}
