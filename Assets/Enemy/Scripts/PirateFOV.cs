using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [Range (1, 300)]
    [SerializeField] internal float detectionPoints;

    [Header("Auxillary Elements")]
    public bool hasSeenPlayerFirstTime = false;
    public GameObject playerRef;
    public GameObject castPoint;

    [Header("UI Stealth Detection")]
    public Image eyeClosed;
    public Image eyeHalf;
    public Image eyeOpen;
    public PirateStateMachine enemyStateMach;

    internal void Start()
    {
        StartCoroutine(FOVRoutine());
        detectionPoints = 0;
    }

    internal void Update()
    {
        Detection();
        StealthDetection();
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

    internal void Detection()
    { 
        if(canSeePlayer == true)
        {
            detectionPoints++;
            if (detectionPoints > 300)
            {
                detectionPoints = 300;
            }
        }
        else
        {
            detectionPoints -= 25 * Time.deltaTime;
            if(detectionPoints < 0)
            {
                detectionPoints = 0;
            }
        }
    }

    public void StealthDetection()
    {
        if (detectionPoints <= 0)
        {
            eyeClosed.enabled = true;
            eyeHalf.enabled = false;
            eyeOpen.enabled = false;
        }

        if (detectionPoints > 0)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }

        if (detectionPoints >= 300)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = false;
            eyeOpen.enabled = true;
        }

        if (detectionPoints < 300 && enemyStateMach.hasLostPlayer == true)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }
    }
}
