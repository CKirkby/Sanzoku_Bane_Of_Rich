using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PiratePatrol : MonoBehaviour
{
    [SerializeField]
    PirateManager pManager;

    [Header("Patrol Elements")]
    internal float startWaitTime = 4;
    internal float timeToRotate = 2;
    internal float _WaitTime;
    internal float _TimeToRotate;
    internal bool isPatrolling = true;

    [Header("Waypoints")]
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    internal void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void Patrol()
    {
        if (pManager.pFOV.canSeePlayer == false && pManager.pFOV.hasSeenPlayerFirstTime == false)
        {
            //Adds the float for current waypoint into the array and begins to move towards them in order
            Transform wp = waypoints[currentWaypoint];
            if (Vector3.Distance(transform.position, wp.transform.position) < 0.25f)
            {
                // currentWaypoint = (currentWaypoint + Random.Range(0, 7)) % waypoints.Length;
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            }
            else
            {
                pManager.navMeshAgent.SetDestination(wp.position);
                //transform.LookAt(wp.position);
            }
        }

        pManager.pAnimator.SetBool("isRunning", false);

    }
}


