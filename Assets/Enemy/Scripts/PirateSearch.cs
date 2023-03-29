using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateSearch : MonoBehaviour
{
    [SerializeField]
    PirateManager pManager;

    [Header("Searching Parameters")]
    [SerializeField] internal float walkRadius;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    internal void SearchForPlayer()
    {
        Vector3 finalPosition;

        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        finalPosition = hit.position;

        if (finalPosition.x < 0)
        {
            
        }
    }

    internal IEnumerator SearchWait()
    {
        return null; 
    }
}
