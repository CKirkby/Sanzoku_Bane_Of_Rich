using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateSearch : MonoBehaviour
{
    [SerializeField]
    PirateManager pManager;

    [Header("Searching Parameters")]
    [SerializeField] internal float range;
    [SerializeField] internal Transform CenterPoint;

    //Choses a random vector within a sphere given by a custom range radius and then walks to it. 
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;  
    }

    internal void SearchForPlayer()
    {
        if (pManager.navMeshAgent.remainingDistance <= pManager.navMeshAgent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(CenterPoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1f);
                pManager.navMeshAgent.SetDestination(point);
            }
        }
    }

}
