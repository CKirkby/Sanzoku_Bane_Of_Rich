using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class PirateStateMachine : MonoBehaviour
{
    [SerializeField] PirateManager pManager;

    internal enum PStateMachine {Idle, Patrolling, Chasing, Alert, Attacking}
    [SerializeField] internal PStateMachine pCurrentState = PStateMachine.Patrolling ;

   
    //Start of state machine ------------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        switch (pCurrentState)
        {
             case PStateMachine.Idle:
                     pManager.pAnimator.SetBool("isIdle", true);
                 break;
 
             case PStateMachine.Patrolling:
                     pManager.navMeshAgent.speed = 0.8f;
                     pManager.pPatrol.Patrol();
                     pManager.pAnimator.SetBool("isWalking", true);
                     StartChasing();
                 break;
       
            case PStateMachine.Chasing:
                     pManager.pAnimator.SetBool("isRunning", true);
               
                     pManager.navMeshAgent.speed = 4f;
                     transform.LookAt(pManager.player.transform.position);
                     pManager.navMeshAgent.SetDestination(pManager.player.transform.position);
                     if (Vector3.Distance(transform.position, pManager.player.transform.position) < 4f)
                     {
                        pCurrentState = PStateMachine.Attacking;
                     }
                     EndChasing();
                break;

            case PStateMachine.Alert:
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
    //End of state machine -----------------------------------------------------------------------------------------------------------------------------------------------

    internal void StartChasing()
    {
        if(pManager.pFOV.canSeePlayer == true)
        {
            pManager.navMeshAgent.speed = 0;
            pManager.pAnimator.SetBool("hasSeenPlayer", true);
            StartCoroutine(WaitForAnim());
        }
        else
        {
            pManager.pAnimator.SetBool("hasSeenPlayer", false);
        }
    }

    internal void EndChasing()
    {
        if (pManager.pFOV.canSeePlayer == false)
        {
            pCurrentState = PStateMachine.Alert;
        }
    }

    private IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(2.3f);
        pCurrentState = PStateMachine.Chasing;
    }

    internal IEnumerator AttackingAnim()
    {

        if(Vector3.Distance(transform.position, pManager.player.transform.position) < 3.5f && Vector3.Distance(transform.position, pManager.player.transform.position) > 2.6f)
        {
            pManager.pAnimator.SetBool("isJumpAttack", true);
            yield return new WaitForSeconds(3.2f);
            pManager.pAnimator.SetBool("isJumpAttack", false);
        }
        else if (Vector3.Distance(transform.position, pManager.player.transform.position) > 2.6f)
        {
            pManager.pAnimator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(3.5f);
            pManager.pAnimator.SetBool("isAttacking", false);
        }

        if (Vector3.Distance(transform.position, pManager.player.transform.position) > 3.5f)
        { 
            pCurrentState = PStateMachine.Chasing;
        }
        else
        {
            pCurrentState = PStateMachine.Attacking;
        }
    }
}
