using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMYATTACK : MonoBehaviour
{
    public enum spawnst {spawning , waiting , counting};
    [System.Serializable]
    public class spawn
    {
        public string Name;
        public Transform Target;
        public int countene;
        public float Rate;
    }
    public spawn[] Waves;
    private int NEXTWAVE = 0;

    public Transform[] spawnpoints;

    public float spawndelatime = 5f;
    public float wavecount;
   
    private float searchcount = 1f;

    private spawnst sta=spawnst.counting;

    public ENEMYATTACK attack;
    private void Awake()
    {
        attack = this;
    }

    private void Start()
    {
        if (spawnpoints.Length == 0)
        {
            Debug.LogError("No spawning");
        }
        wavecount = spawndelatime;
    }

    private void Update()
    {
        if(sta==spawnst.waiting)
        {
            if(!Enemyaliveornot())
            {
                wavecomplete();
            }
            else
            {
                return;
            }
        }

        if(wavecount<=0)
        {
            if(sta != spawnst.spawning)
            {
                StartCoroutine(Spawnwave(Waves[NEXTWAVE]));
            }
        }
        else
        {
            wavecount -= Time.deltaTime;
        }
    }
    void wavecomplete()
    {
        sta = spawnst.counting;
        wavecount = spawndelatime;

        if(NEXTWAVE + 1 > Waves.Length - 1)
        {
            NEXTWAVE = 0;
        }
        NEXTWAVE++;
    }
    private bool Enemyaliveornot()
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

    IEnumerator Spawnwave (spawn enemyy)
    {
        sta=spawnst.spawning;

        for(int i = 0; i < enemyy.countene; i++)
        {
            spawnenemy(enemyy.Target);
            yield return new WaitForSeconds(1/enemyy.Rate);
        }

        sta = spawnst.waiting;
        yield break;
    }
    void spawnenemy(Transform _Enemy1)
    {
        Transform _Enemy2 = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(_Enemy1, _Enemy2.transform.position, _Enemy2.transform.rotation);
    }
}