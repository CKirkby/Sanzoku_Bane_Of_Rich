using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PirateStateMachine : MonoBehaviour
{
    [SerializeField]
    PirateManager pManager;

    internal enum PStateMachine {Idle, Patrolling, Chasing, Alert, Attacking}
    [SerializeField]
    internal PStateMachine pCurrentState;


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
                //Sets the Pirate on a patrol path
                pManager.pPatrol.Patrol();
                pManager.pChase.playerSeen = false;
                pManager.pAnimator.SetBool("isWalking", true);

                //Changes State to chasing if too close.
                pManager.pChase.TooClose();
                break;

            case PStateMachine.Chasing:
                pManager.pChase.playerSeen = true;
                pManager.pAnimator.SetBool("isRunning", true);
                //Move towards the player
                transform.LookAt(pManager.player.position);
                transform.Translate(Vector3.forward * pManager.speed * Time.deltaTime);
                pManager.pChase.TooFar();
                break;

            case PStateMachine.Alert:
                pManager.pPatrol.Patrol();
                pManager.pAnimator.SetBool("isAlert", true);
                pManager.pChase.playerSeen = false;
                pManager.speed = 2f;
                pManager.pChase.TooClose();
                break;
        }






    }
}
