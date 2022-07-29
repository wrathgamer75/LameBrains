using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMYATTACK : MonoBehaviour
{
    public enum spawnst {spawning , waiting , counting};//creating Enum for spawning states
    [System.Serializable]
    public class spawn//all the stuff we want 
    {
        public string Name;
        public Transform Target;
        public int countene;
        public float Rate;
    }
    public spawn[] Waves;//array of the class
    private int NEXTWAVE = 0;//store index of the wave that we want to create next

    public Transform[] spawnpoints;

    public float spawndelatime = 5f;//time between waves
    public float wavecount;//default wave count which is 0
   
    private float searchcount = 1f;//same as wave count we are searching for enemies

    private spawnst sta=spawnst.counting;//Creating variable for enum

    private void Start()
    {
        wavecount = spawndelatime;//here we are assigining the time count at what time the wave will spawn
    }

    private void Update()
    {
        //waiting means we spawned the wave so we have to wait for the player to kill the enemys
        if (sta==spawnst.waiting)
        {
            if(!Enemyaliveornot())
            {
                wavecomplete();
            }
            else
            {
                return;//if still  enemy alive we will return
            }
        }

        if(wavecount<=0)//if the waves are over that is = 0
        {
            if(sta != spawnst.spawning)
            {
                StartCoroutine(Spawnwave(Waves[NEXTWAVE]));//spawning waves with calling the method of ienumerator
            }
        }
        else
        {
            wavecount -= Time.deltaTime;//decrease the time to 0 so the wave will start spawning
        }
    }
    void wavecomplete()//here we are completing the wave and spawning the next wave
    {
        sta = spawnst.counting;
        wavecount = spawndelatime;

        if(NEXTWAVE + 1 > Waves.Length - 1)//next wave is bigger than the no.of waves that we have given
        {
            NEXTWAVE = 0;//completed all waves
        }
        else
        {
            NEXTWAVE++;//if we didnt reach the final wave it will continue to next wave
        }
        
    }
    private bool Enemyaliveornot()//checking if enemy is still alive or not so we are using bool
    {
        searchcount -= Time.deltaTime;
        if(searchcount<=0)
        {
            searchcount = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        } 
        return true;
    }

    IEnumerator Spawnwave (spawn enemyy)//we use this for waititng for certain amount of seconds inside the method
    {
        sta=spawnst.spawning;//now we are actually spawning

        for(int i = 0; i < enemyy.countene; i++)//how many enemy we want to spawn and keep on looping
        {
            spawnenemy(enemyy.Target);
            yield return new WaitForSeconds(1f/enemyy.Rate);//for every enemy spawn it will wait for some seconds that which we given
        }

        sta = spawnst.waiting;//after one wave has been spawned we should wait unitll its completed
        yield break;
    }
    void spawnenemy(Transform _Enemy1)//instantiating enemy from spwan points
    {
        Transform SpawnPoint = spawnpoints[Random.Range(0, spawnpoints.Length)];//spawning from empty gameobjects choosing the random empty object to spawn
        Instantiate(_Enemy1, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
    }
}