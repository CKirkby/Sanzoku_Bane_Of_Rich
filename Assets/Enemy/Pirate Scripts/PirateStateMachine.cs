using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class PirateStateMachine : MonoBehaviour
{
    [SerializeField]
    PirateManager pManager;

    internal enum PStateMachine {Idle, Patrolling, Chasing, Alert, Attacking}
    [SerializeField]
    internal PStateMachine pCurrentState = PStateMachine.Patrolling ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {

        Debug.Log(pCurrentState);

        switch (pCurrentState)
        {
            case PStateMachine.Idle:
                pManager.pAnimator.SetBool("isIdle", true);
                break;
 
             case PStateMachine.Patrolling:
                //Sets the Pirate on a patrol pat
                pManager.speed = 20f;
                     pManager.pPatrol.Patrol();
                     pManager.pAnimator.SetBool("isWalking", true);
                     StartChasing();
                 break;
       
            case PStateMachine.Chasing:
                    pManager.pAnimator.SetBool("isRunning", true);
                //Move towards the player
                    pManager.speed = 4f;
                    transform.LookAt(pManager.player.position);
                    transform.Translate(Vector3.forward * pManager.speed * Time.deltaTime);
                    EndChasing();
                break;

            case PStateMachine.Alert:
                    pManager.pPatrol.Patrol();
                    pManager.pAnimator.SetBool("isAlert", true);
                    pManager.speed = 2f;
                    StartChasing();
                break;

                default: 
                    break;
        }
    }

    internal void StartChasing()
    {
        if(pManager.pFOV.canSeePlayer == true)
        {
           pCurrentState = PStateMachine.Chasing;
        }
    }

    internal void EndChasing()
    {
        if (pManager.pFOV.canSeePlayer == false)
        {
            pCurrentState = PStateMachine.Alert;
        }
    }
}
