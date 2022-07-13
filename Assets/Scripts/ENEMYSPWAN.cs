using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYSPWAN : MonoBehaviour
{
    public GameObject[] enemy1;
    public float enemydelay;
    public bool stopspawing;
    public float enemyspawntime;
    [SerializeField]
    private int enemycount = 0;
    ENEMYSPWAN instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        InvokeRepeating("EnemySpawn", enemyspawntime, enemydelay);
    }
    private void Update()
    {
        stopspawing = enemycount >= 7;
    }
    public void EnemySpawn()
    {
        if (!stopspawing)
        {
            for (int i = 0; i < enemy1.Length; i++)
            {
                Instantiate(enemy1[i], transform.position, transform.rotation);
                
            }
            enemycount++;
        }
        else if(stopspawing)
        {
            for(int i = 0; i > enemy1.Length; i++)
            {
                Instantiate(enemy1[i], transform.position, transform.rotation);
            }
            enemycount++;
        }
        else
        {
            return;
        }

    }
}