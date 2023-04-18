using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionHandler : MonoBehaviour
{
    [Header("UI Stealth Detection")]
    public Image eyeClosed;
    public Image eyeHalf;
    public Image eyeOpen;

    [Header("Refrences")]
    public PirateStateMachine enemyStateMach1;
    public PirateStateMachine enemyStateMach2;
    public PirateFOV enemyFOV1;
    public PirateFOV enemyFOV2;

    void Start()
    {
        
    }

    void Update()
    {
        StealthDetection();
        StealthDetection2();
    }

    public void StealthDetection()
    {
        if (enemyFOV1.detectionPoints <= 0)
        {
            eyeClosed.enabled = true;
            eyeHalf.enabled = false;
            eyeOpen.enabled = false;
        }

        if (enemyFOV1.detectionPoints > 0)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }

        if (enemyFOV1.detectionPoints >= 300)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = false;
            eyeOpen.enabled = true;
        }

        if (enemyFOV1.detectionPoints < 300 && enemyStateMach1.hasLostPlayer == true)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }
    }

    public void StealthDetection2()
    {
        if (enemyFOV2.detectionPoints <= 0)
        {
            eyeClosed.enabled = true;
            eyeHalf.enabled = false;
            eyeOpen.enabled = false;
        }

        if (enemyFOV2.detectionPoints > 0)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }

        if (enemyFOV2.detectionPoints >= 300)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = false;
            eyeOpen.enabled = true;
        }

        if (enemyFOV2.detectionPoints < 300 && enemyStateMach2.hasLostPlayer == true)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }
    }
}
