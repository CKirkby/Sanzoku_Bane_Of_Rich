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

    // Update is called once per frame

    void Update()
    {

        //Debug.Log(pCurrentState);

        switch (pCurrentState)
        {
            case PStateMachine.Idle:
                pManager.pAnimator.SetBool("isIdle", true);
                break;
 
             case PStateMachine.Patrolling:
                //Sets the Pirate on a patrol pat
                pManager.navMeshAgent.speed = 0.8f;
                     pManager.pPatrol.Patrol();
                     pManager.pAnimator.SetBool("isWalking", true);
                     StartChasing();
                 break;
       
            case PStateMachine.Chasing:
                    pManager.pAnimator.SetBool("isRunning", true);
                //Sets the Pirate to chase the player.
                    pManager.navMeshAgent.speed = 4f;
                    transform.LookAt(pManager.player.transform.position);
                    pManager.navMeshAgent.SetDestination(pManager.player.transform.position);
                    if (Vector3.Distance(transform.position, pManager.player.transform.position) < 3.5f)
                    {
                        pCurrentState = PStateMachine.Attacking;
                    }
                    EndChasing();
                break;

            case PStateMachine.Alert:
                //Returns the Pirate to patrolling but in alert state.
                    pManager.pPatrol.Patrol();
                    pManager.pAnimator.SetBool("isAlert", true);
                    pManager.navMeshAgent.speed = 1.7f;
                    StartChasing();
                break;
            
            case PStateMachine.Attacking:
                pManager.navMeshAgent.speed = 0f;
                StartCoroutine(AttackingAnim());
                    break;

                default: 
                    break;
        }
    }

    internal void StartChasing()
    {
        if(pManager.pFOV.canSeePlayer == true)
        {
            pManager.navMeshAgent.speed = 0;
            pManager.pAnimator.SetTrigger ("hasSeenPlayer");
            StartCoroutine(WaitForAnim());
        }
    }

    internal void EndChasing()
    {
        if (pManager.pFOV.canSeePlayer == false)
        {
            pCurrentState = PStateMachine.Alert;
            pManager.pAnimator.SetTrigger("hasLostPlayer");
        }
    }

    private IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(2.3f);
        pCurrentState = PStateMachine.Chasing;
    }

    internal IEnumerator AttackingAnim()
    {
        pManager.pAnimator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(3.5f);
      
        if (Vector3.Distance(transform.position, pManager.player.transform.position) > 3.5f)
        {
            pManager.pAnimator.SetBool("isAttacking", false);
            pCurrentState = PStateMachine.Chasing;
        }
        else
        {
            pCurrentState = PStateMachine.Attacking;
        }
    }
}
