using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    [Range(0f, 100f)] public float speed;
    [Range(1, 500)] public float walkRadius;

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
