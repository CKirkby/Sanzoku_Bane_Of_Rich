using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PirateChase : MonoBehaviour
{
    [SerializeField]
    internal PirateManager pManager;
    [SerializeField]
    internal Transform castPosition;

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
        TooClose();
        TooFar();
    }

    internal void GetDistance()
    {
        // Debug.Log(distPlayer);
        float distPlayer = Vector3.Distance(pManager.enemy.transform.position, pManager.player.transform.position);
    }
    internal void TooClose()
      {
          if (distPlayer <= 5f)
          {
              playerSeen = true;
          }
      }

    internal void TooFar()
    {
        if (distPlayer >= 5f)
        {
            playerSeen = false;
        }
            
        
    }

    internal void Chasingtime()
    {
        pManager.pStateMachine.pCurrentState = PirateStateMachine.PStateMachine.Chasing;
    }

    internal void Alerttime()
    {
        pManager.pStateMachine.pCurrentState = PirateStateMachine.PStateMachine.Alert;
    }
}


