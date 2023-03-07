using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratePatrol : MonoBehaviour
{
    [SerializeField]
    PirateManager pManager;

    [Header("Waypoints")]
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Patrol()
    {
        if (pManager.pSearch.playerSeen == false)
        {
            //Adds the float for current waypoint into the array and begins to move towards them in order
            Transform wp = waypoints[currentWaypoint];
            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                currentWaypoint = (currentWaypoint + Random.Range(0, 7)) % waypoints.Length;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, wp.position, pManager.speed * Time.deltaTime);
                transform.LookAt(wp.position);
            }
        }



    }


}
