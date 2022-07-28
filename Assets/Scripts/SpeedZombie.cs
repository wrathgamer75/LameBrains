using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedZombie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator anim;

    int zombdmg = 1;

    float timeinRange = 0.0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < 9)
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
        timeinRange += Time.deltaTime;
        if (timeinRange > 1.2f)
        {

            CarAdditional.carhealthdamage(zombdmg);
            timeinRange = 0.0f;
        }

    }
    private void gotoenemy()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("bool", true);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            CarAdditional.upgrade(1);
        }
    }
}