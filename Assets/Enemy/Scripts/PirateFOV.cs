using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateFOV : MonoBehaviour
{
    [SerializeField]
    internal PirateManager pManager;

    [Header("Raycast Options")]
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [Header("FOV Options")]
    public float radius;
    [Range(0,360)]
    public float angle;

    [Header("Detection Elements")]
    public bool canSeePlayer;
    [SerializeField] internal float detectionPoints;
    [SerializeField] internal float minDetectPoints = 0;
    [SerializeField] internal float maxDetectPoints = 10;

    [Header("Auxillary Elements")]
    public bool hasSeenPlayerFirstTime = false;
    public GameObject playerRef;
    public GameObject castPoint;
    
    internal void Start()
    { 
        StartCoroutine(FOVRoutine());
        detectionPoints = 0;
        detectionPoints = Mathf.Clamp(detectionPoints, minDetectPoints, maxDetectPoints);
    }

    internal IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    internal void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(castPoint.transform.position, radius, targetMask);

        if(rangeChecks.Length > 0 )
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - castPoint.transform.position).normalized;

            if(Vector3.Angle(castPoint.transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(castPoint.transform.position, target.position);

                if (!Physics.Raycast(castPoint.transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    Debug.Log("I see you");
                    canSeePlayer = true;
                    Detection();
                }
                else
                {
                    canSeePlayer = false;
                    detectionPoints --;
                }
            }
            else
            {
                canSeePlayer = false;
                detectionPoints--;
            }
        }
        else if (canSeePlayer)
        { 
            canSeePlayer = false;
            detectionPoints--;
        }
    
    }

    internal void Detection()
    { 
        if(canSeePlayer == true)
        {
            detectionPoints++;
        }
        else
        {
            detectionPoints--;
        }
    }

}
