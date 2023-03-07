using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateStateMachine : MonoBehaviour
{
    [SerializeField]
    PirateManager pManager;

    public enum PStateMachine {Idle, Patrolling, Chasing, Attacking}
    public PStateMachine pCurrentState = PStateMachine.Idle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (pCurrentState)
        {
            case PStateMachine.Idle:
                pManager.speed = 0f;
                pManager.pAnimator.SetBool("isWalking", false);
                break;

            case PStateMachine.Patrolling:
                pManager.pPatrol.Patrol();
                pManager.pAnimator.SetBool("isWalking", true);
                break;
        }






    }
}
