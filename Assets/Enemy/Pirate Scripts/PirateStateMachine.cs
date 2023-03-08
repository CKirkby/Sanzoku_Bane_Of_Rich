using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

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
        switch (pCurrentState)
        {
            case PStateMachine.Idle:
                pManager.speed = 0f;
                pManager.pAnimator.SetBool("isIdle", true);
                break;
           
            case PStateMachine.Patrolling:
                //Sets the Pirate on a patrol path
                    Debug.Log("Im on Patrol");
                    pManager.pPatrol.Patrol();
                    pManager.pAnimator.SetBool("isWalking", true);
                    pManager.pChase.TooClose();
                break;

            case PStateMachine.Chasing:
                    Debug.Log("Im Chasing you");
                    pManager.pAnimator.SetBool("isRunning", true);
                   //Move towards the player
                    transform.LookAt(pManager.player.position);
                    transform.Translate(Vector3.forward * pManager.speed * Time.deltaTime);
                    pManager.pChase.TooFar();
                break;

            case PStateMachine.Alert:
                    Debug.Log("I am Alert");
                    pManager.pPatrol.Patrol();
                    pManager.pAnimator.SetBool("isAlert", true);
                    pManager.speed = 1f;
                    pManager.pChase.TooClose();
                break;

                default: 
                    break;
        }






    }
}
