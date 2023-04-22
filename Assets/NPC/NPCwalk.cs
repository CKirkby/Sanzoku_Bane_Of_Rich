using UnityEngine.AI;
using UnityEngine;
using System.Collections;
 
public class NPCwalk : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    public Transform target;
    private NavMeshAgent agent;
    public float timer;

    public Animator animator;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsWalking", true);
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
