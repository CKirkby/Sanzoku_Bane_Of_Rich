using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{

    private BTnode _root;
    private bool startingBehaviour;
    private Coroutine currentBehaviour;

    //Creates a dictionary of data to store any data
    public Dictionary<string, object> Blackboard { get; set; }
    public BTnode Root { get { return _root; } }

   
    void Start()
    {
        //Inialisation for behaviourtree
        Blackboard = new Dictionary<string, object>();
        Blackboard.Add("WorldBounds", new Rect(0, 0, 5, 5));

        //InitalBehaviour will not start
        startingBehaviour = false;

        _root = new BTnode(this);


    }

   
    void Update()
    {
        if (!startingBehaviour)
        {
           currentBehaviour = StartCoroutine(RunBehaviour());
            startingBehaviour = true;

        }
    }


    private IEnumerator RunBehaviour()
    {
        BTnode.nodeState state = Root.Execute();
        while (state == BTnode.nodeState.RUNNING)
        {
            Debug.Log("Root Result:" + state);
            yield return null;
            state = Root.Execute();
        }

        Debug.Log("Behaviour has finished with" + state);

    }

}
