using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PirateChase : MonoBehaviour
{
    [SerializeField]
    internal PirateManager pManager;

    [Header("Player refrences")]
    internal float distPlayer;
    internal bool playerSeen = false;
    internal float tooCloseDistance = 5f;
    internal bool tooClose = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetDistance();
    }

    internal void GetDistance()
    {
       // Debug.Log(distPlayer);
        distPlayer = Vector3.Distance(pManager.enemy.transform.position, pManager.player.transform.position);
    }

    internal void TooClose()
    {
        if (distPlayer <= 5)
        {
            tooClose= true;
            Debug.Log("TOO CLOSE IS" + tooClose);
            if(tooClose == true)
            {
            Debug.Log("TOO CLOSE");
            pManager.pStateMachine.pCurrentState = PirateStateMachine.PStateMachine.Chasing;
            playerSeen = true;
            }
        }
    }

    internal void TooFar()
    {
        if (distPlayer >= 5)
        {
            Debug.Log("TOO FAR");
            pManager.pStateMachine.pCurrentState = PirateStateMachine.PStateMachine.Alert;
            playerSeen = false;
        }
    }
}





