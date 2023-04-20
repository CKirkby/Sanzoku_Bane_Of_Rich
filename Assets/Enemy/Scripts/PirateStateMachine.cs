using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PirateStateMachine : MonoBehaviour
{
    [SerializeField] PirateManager pManager;
    [SerializeField] private int cooldownTime;
    [SerializeField] private int nextAttackTime;
    [SerializeField] internal float timeSinceLostPlayer = 0f;
    internal bool hasLostPlayer = false;
    public bool isCurrentlyAttacking = false;
    internal float alertStartTime;

    public PlayerHealth pHealth;

    [Header("Attack Parameterse")]
    [SerializeField] internal BoxCollider attackzone;

    internal enum PStateMachine {Idle, Patrolling, Chasing, Alert, Attacking, Searching}
    [SerializeField]
    internal PStateMachine pCurrentState = PStateMachine.Patrolling ;

    private void Start()
    {
        pHealth = Component.FindObjectOfType<PlayerHealth>();
    }


    void Update()
    {
    // START OF STATE MACHINE ---------------------------------------------------------------------------------------------------------------------
        switch (pCurrentState)
        {
            case PStateMachine.Idle:
                pManager.pAnimator.SetBool("isIdle", true);
                //CREATE EXIT
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
                    if (Vector3.Distance(transform.position, pManager.player.transform.position) < 2f)
                    {
                        pCurrentState = PStateMachine.Attacking;
                    }
                    EndChasing();
                break;

            case PStateMachine.Alert:
                //Returns the Pirate to patrolling but in alert state.
                    pManager.pPatrol.Patrol();
                    hasLostPlayer = false;
                    pManager.pAnimator.SetBool("isAlert", true);
                    pManager.pFOV.radius = 7;
                    pManager.navMeshAgent.speed = 1.7f;
                        StartChasing();
                    alertStartTime = Time.time;
                break;

            case PStateMachine.Searching:
                if (hasLostPlayer == true)
                {
                    Debug.Log("Searching for player");
                    pManager.pAnimator.SetTrigger("hasLostPlayer");
                    
                    pManager.pSearch.SearchForPlayer();
                    Debug.Log("Still searching");
                    StartCoroutine(SearchingTime());
                }
                break;
            
            case PStateMachine.Attacking:
                pManager.navMeshAgent.speed = 0f;
                StartCoroutine(AttackingAnim());
                isCurrentlyAttacking = true;
                    break;

                default: 
                    break;
        }
    }

    // END OF STATE MACHINE ------------------------------------------------------------------------------------------------------------------------

    internal void StartChasing()
    {
        if(pManager.pFOV.detectionPoints >= 300)
        {
                pManager.pAnimator.SetTrigger("hasSeenPlayer");
                StartCoroutine(WaitForDrawSword());
        }
    }

    internal void EndChasing()
    {
        //Sets the state to alert if the player is not in veiw and detection points are 0.
        if (pManager.pFOV.detectionPoints <= 0 && pManager.pFOV.canSeePlayer == false)
        {
            if(pCurrentState == PStateMachine.Alert && Time.time - alertStartTime > 5f)
            {
                pCurrentState = PStateMachine.Patrolling;
                pManager.pAnimator.SetBool("isAlert", true);
            }
            else
            {
                pCurrentState = PStateMachine.Searching;
                hasLostPlayer = true;
            }
        }
    }

    private IEnumerator WaitForDrawSword()
    {
        //Allows the draw sword animation to play before chasing.
        yield return new WaitForSeconds(1.15f);
        pCurrentState = PStateMachine.Chasing;
    }

    internal IEnumerator AttackingAnim()
    {
        //Attacks and then checks if the player is still within attacking distance to either attack again or chase after them.
        pManager.pAnimator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(2f);
      
        if (Vector3.Distance(transform.position, pManager.player.transform.position) > 2f)
        {
            pManager.pAnimator.SetTrigger("isTooFar");
            pCurrentState = PStateMachine.Chasing;
            isCurrentlyAttacking = false;
        }
        else
        {
            pManager.pAnimator.SetTrigger("isTooClose");
            pCurrentState = PStateMachine.Attacking;
        }
    }

    internal IEnumerator SearchingTime()
    {
        yield return new WaitForSeconds(10);

        pCurrentState = PStateMachine.Alert;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the player is within the trigger while the enemy attacks then it will do damage. 
            if (attackzone.isTrigger == true && isCurrentlyAttacking == true)
            {
                if (other.CompareTag("Player"))
                    pHealth.ApplyDamage(51);
            }
    }
}
