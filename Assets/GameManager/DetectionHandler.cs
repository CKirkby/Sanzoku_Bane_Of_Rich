using UnityEngine;
using UnityEngine.UI;

public class DetectionHandler : MonoBehaviour
{

    [Header("UI Stealth Detection")]
    public Image eyeClosed;
    public Image eyeHalf;
    public Image eyeOpen;
    [Range(1, 300)]
    public float detectionPoints;

    //Refrences
    public PirateFOV pFOV1;
    public PirateFOV pFOV2;
    public PirateFOV pFOV3;
    public PirateFOV pFOV4;
    public PirateStateMachine enemyStateMach1;
    public PirateStateMachine enemyStateMach2;
    public PirateStateMachine enemyStateMach3;
    public PirateStateMachine enemyStateMach4;


    void Start()
    {
        detectionPoints = 0;
    }

    void Update()
    {
        Detection();
        StealthDetection1();
        StealthDetection2();
        StealthDetection3();
        StealthDetection4();
    }

    internal void Detection()
    {
        //Builds up detection points if player is detected by raycast
        if (pFOV1.canSeePlayer == true || pFOV2.canSeePlayer == true || pFOV3.canSeePlayer == true || pFOV4.canSeePlayer == true)
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
            if (detectionPoints < 0)
            {
                detectionPoints = 0;
            }
        }
    }
    
    public void StealthDetection1()
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

        if (detectionPoints < 300 && enemyStateMach1.hasLostPlayer == true)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }
    }
    
    public void StealthDetection2()
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

        if (detectionPoints < 300 && enemyStateMach2.hasLostPlayer == true)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }
    }

    public void StealthDetection3()
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

        if (detectionPoints < 300 && enemyStateMach3.hasLostPlayer == true)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }
    }

    public void StealthDetection4()
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

        if (detectionPoints < 300 && enemyStateMach4.hasLostPlayer == true)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }
    }
}

