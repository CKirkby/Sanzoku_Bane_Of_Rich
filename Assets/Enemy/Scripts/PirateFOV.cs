using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateFOV : MonoBehaviour
{
    //Thank you to https://www.youtube.com/@comp3interactive for helping to create this script

    [SerializeField]
    internal PirateManager pManager;

    [Header("Raycast Options")]
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [Header("FOV Options")]
    public float radius;
    [Range(0, 360)]
    public float angle;

    [Header("Detection Elements")]
    public bool canSeePlayer;

    [Header("Auxillary Elements")]
    public bool hasSeenPlayerFirstTime = false;
    public GameObject playerRef;
    public GameObject castPoint;
    public DetectionHandler detectionHandler;

    internal void Start()
    {
        StartCoroutine(FOVRoutine());
        detectionHandler = Component.FindObjectOfType<DetectionHandler>();
    }

    internal void Update()
    {

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

        if (rangeChecks.Length > 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - castPoint.transform.position).normalized;

            //Creates the anle for the FOV.
            if (Vector3.Angle(castPoint.transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(castPoint.transform.position, target.position);

                //If the layermask is not obstruction layer, the playter can now be detected by the raycast within the angle given
                if (!Physics.Raycast(castPoint.transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    Debug.Log("I see you");
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
