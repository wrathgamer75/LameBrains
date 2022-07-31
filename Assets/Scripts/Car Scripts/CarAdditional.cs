using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarAdditional : MonoBehaviour
{
    public GameObject lights;
    public static float health = 100;
    public static float Maxhealth = 100;

    public static float carSpeed;
    public WheelCollider frontLeftCollider;

    public Image HPbar;
    public Image NxtUp;
    //public int speed;
    public static float upgradecounter = 0;
    public static float allupgrades = 100;
    public static float upgradebar;
    static float lerpspeed;

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
        carhptxt.text = health + "";
        upgrades.text = upgradecounter+"";
        if(health>Maxhealth)
        {
            health = Maxhealth;
        }

        switch(upgradecounter)
        {
            case 10:
                upgrade1.SetActive(true);
                health += 50;
                Maxhealth = 110;
                upgradebar = 0;
                break;
            case 20:
                upgrade2.SetActive(true);
                health += 60;
                Maxhealth = 120;
                upgradebar = 0;
                break;
            case 30:
                upgrade3.SetActive(true);
                health += 70;
                Maxhealth = 130;
                upgradebar = 0;
                break;
            case 40:
                upgrade4.SetActive(true);
                health += 80;
                Maxhealth = 140;
                upgradebar = 0;
                break;
            case 50:
                upgrade5.SetActive(true);
                health += 90;
                Maxhealth = 150;
                upgradebar = 0;
                break;
            case 60:
                upgrade6.SetActive(true);
                health += 100;
                Maxhealth = 160;
                upgradebar = 0;
                break;
            case 70:
                upgrade7.SetActive(true);
                health += 110;
                Maxhealth = 170;
                upgradebar = 0;
                break;
            case 80:
                upgrade8.SetActive(true);
                health += 120;
                Maxhealth = 180;
                upgradebar = 0;
                break;
            case 90:
                health += 130;
                Maxhealth = 190;
                upgradebar = 0;
                break;
            case 100:
                health += 140;
                Maxhealth = 200;
                upgradebar = 0;
                break;
        }

        //if (Input.GetKeyDown(KeyCode.H)) ;
        //{
        //    lights.SetActive(false);
        //}
        if (health == 0)
        {
            this.gameObject.SetActive(false);

            //GAMER OVER SCENE HERE!!!
        }
        carSpeed = (2 * Mathf.PI * frontLeftCollider.radius * frontLeftCollider.rpm * 60) / 1000;
        


        CarHPBar();
        nxtupg();
        ColorChanger();
        lerpspeed = 3f * Time.deltaTime;
        

    }
    public static void carhealthdamage(int zombdmg)
    {
        health -= zombdmg;
    }
    public static void slowdamange(int zombdmg)
    {
        if(carSpeed<=30)
        {
            health -=zombdmg;
        }
    }
    public static void upgrade(int upgradescnt)
    {
        upgradecounter += upgradescnt;
        upgradebar++;
    }
    public void CarHPBar()
    {
        HPbar.fillAmount = Mathf.Lerp(HPbar.fillAmount, health / Maxhealth, lerpspeed);
    }
    public void nxtupg()
    {
        NxtUp.fillAmount = Mathf.Lerp(NxtUp.fillAmount,upgradebar / 10, lerpspeed);
    }
    public void ColorChanger()
    {
        Color healthcolor = Color.Lerp(Color.red,Color.green, (health / Maxhealth));
        HPbar.color = healthcolor;
        Color XPbarcolor = Color.Lerp(Color.cyan, Color.blue, (upgradebar / 10));
        NxtUp.color = XPbarcolor;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(carSpeed>=100)
        {
            health--;
        }
    }
}
