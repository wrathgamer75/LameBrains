using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemymoment1 : MonoBehaviour
{
    public Transform target;
    public Transform[] wayPoints;
    Transform nextDestination;
    int destinationLoop;
    public float rotationSpeed;
    public float chasedis, attackdis;
    [SerializeField]
    private bool dead = false;
    public enum AIState { Patrol,Chase,Attack,dead};
    public AIState enemyState = AIState.Patrol;
    private NavMeshAgent agent;
    private Animator anim;
    int zombdmg = 1;

    float timeinRange = 0.0f;

    //NavMeshAgent enemyNavAgent;
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nextDestination = wayPoints[((destinationLoop++) % wayPoints.Length)];
    }

    void Update()
    {
        float enemyplayerdis = Vector3.Distance(transform.position, target.position);

        if (enemyplayerdis > chasedis)
        {
            enemyState = AIState.Patrol;
        }
        else if (enemyplayerdis <= chasedis)
        {
            enemyState = AIState.Chase;
        }
        if(enemyplayerdis < attackdis)
        {
            enemyState = AIState.Attack;
        }
        if(dead == false)
        {
        Movement();
        }
    }


    void Movement()
    {
        switch(enemyState)
        {
            case AIState.Patrol:
                anim.SetBool("bool",true);
                if (Vector3.Distance(transform.position, nextDestination.position) < 1f)
                    nextDestination = wayPoints[(destinationLoop++) % wayPoints.Length];
                agent.SetDestination(nextDestination.position);

                break;
            case AIState.Chase:
                anim.SetBool("bool", true);
                agent.SetDestination(target.position);

                break;
            case AIState.Attack:
                agent.SetDestination(transform.position);
                anim.SetBool("bool", false);
                anim.SetTrigger("Attackanim");
                timeinRange += Time.deltaTime;
                if (timeinRange > 1.2f)
                {

                    CarAdditional.carhealthdamage(zombdmg);
                    timeinRange = 0.0f;
                }

                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            this.gameObject.SetActive(false);
            CarAdditional.upgrade(1);
        }
    }
    //public void ememydead()
    //{
    //    dead = true;
    //    anim.SetBool("bool", false);
    //    anim.SetTrigger("deathtrigger");
    //    Destroy(gameObject, 2f);

    //}
}