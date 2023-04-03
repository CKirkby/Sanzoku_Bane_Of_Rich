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
    [SerializeField] private int cooldownTime;
    [SerializeField] private int nextAttackTime;
    internal bool hasLostPlayer = false;

    internal enum PStateMachine {Idle, Patrolling, Chasing, Alert, Attacking, Searching}
    [SerializeField]
    internal PStateMachine pCurrentState = PStateMachine.Patrolling ;




    void Update()
    {
    // START OF STATE MACHINE ---------------------------------------------------------------------------------------------------------------------
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
                    pManager.pAnimator.SetBool("isChasing", true);
                //Sets the Pirate to chase the player.
                    pManager.navMeshAgent.speed = 2f;
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
                    pManager.pFOV.radius = 7;
                    pManager.navMeshAgent.speed = 1.7f;
                    StartChasing();
                break;

            case PStateMachine.Searching:
                if (hasLostPlayer == true)
                {
                    pManager.pAnimator.SetTrigger("hasLostPlayer");
                    pManager.pSearch.SearchForPlayer();
                    SearchingTime();
                }
                break;
            
            case PStateMachine.Attacking:
                pManager.navMeshAgent.speed = 0f;
                StartCoroutine(AttackingAnim());
                    break;

                default: 
                    break;
        }
    }

    // END OF STATE MACHINE ------------------------------------------------------------------------------------------------------------------------

    internal void StartChasing()
    {
        if(pManager.pFOV.detectionPoints >= 10)
        {
                pManager.pAnimator.SetTrigger("hasSeenPlayer");
                StartCoroutine(WaitForDrawSword());
        }
    }

    internal void EndChasing()
    {
        if (pManager.pFOV.detectionPoints <= 0)
        {
            pCurrentState = PStateMachine.Searching;
            hasLostPlayer = true;
        }
    }

    private IEnumerator WaitForDrawSword()
    {
        yield return new WaitForSeconds(1.15f);
        pCurrentState = PStateMachine.Chasing;
    }

    internal IEnumerator AttackingAnim()
    {
        pManager.pAnimator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(2f);
      
        if (Vector3.Distance(transform.position, pManager.player.transform.position) > 3.5f)
        {
            pCurrentState = PStateMachine.Chasing;
        }
        else
        {
            pCurrentState = PStateMachine.Attacking;
        }
    }

    internal IEnumerator SearchingTime()
    {
        yield return new WaitForSeconds(10);

        pCurrentState = PStateMachine.Alert;
    }
}
