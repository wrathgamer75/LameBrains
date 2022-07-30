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
        target = GameObject.FindGameObjectWithTag("Player").transform;//assigining the Player as a target for the Zombie
    }
    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);//creating the dis between the zombie and player
        if (dist < 7.5)
        {
            stopenemy();

        }
        else
        {
            gotoenemy();
        }

    }
    private void stopenemy()//Here the agent (Zombie) will detect the player and start attacking it wont chase
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
    private void gotoenemy()//if the player is far away Zombie will chase the player
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