using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public float speed = 1.9f;
    public float walkRadius = 50;

    public void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if(agent != null )
        {
            agent.speed = speed;
            agent.SetDestination(RandomLocation());
        }
    }

    public void Update()
    {
        animator.SetBool("IsWalking", true);

        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomLocation());
        }
    }

    public Vector3 RandomLocation()
    {
        //Creates a sphere around the area based on a given radius and then will chose a location within there to walk to. 
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPostion = Random.insideUnitSphere * walkRadius;
        randomPostion += transform.position;

        if(NavMesh.SamplePosition(randomPostion, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }





}
