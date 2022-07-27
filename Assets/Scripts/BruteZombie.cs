using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BruteZombie : MonoBehaviour
{
    [SerializeField] HealthBarScript health;

    public Transform target;
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] float collidetime;
    private bool candamage;
    private void Start()
    {
        candamage = true;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist<9)
        {
            stopenemy();
            
        }
        else
        {
            gotoenemy();
        }
       
    }
    private void stopenemy()
    {
        agent.isStopped = true;
        anim.SetBool("bool", false);
        anim.SetTrigger("Attackanim");
    }
    private void gotoenemy()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("bool", true);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player" && candamage)
        {
            candamage = false;
            StartCoroutine("damagereset");
            health.slider.value--;
            if (health.slider.value == 0)
            {
                anim.SetTrigger("death");
                Destroy(gameObject, 2f);
            }
        }
       
    }
    IEnumerator damagereset()
    {
        yield return new WaitForSeconds(collidetime);
        candamage = true;
    }
}