using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTrandomWalk : BTnode
{


    protected Vector3 NextDestination { get; set; }
    public float speed;
    public BTrandomWalk(BehaviourTree t) : base(t)
    {
        NextDestination = Vector3.zero;
        FindNextDestination();
    }


    public bool FindNextDestination()
    {
        object o;
        bool found = false;
        found = Tree.Blackboard.TryGetValue("WorldBounds", out o);
        if (found)
        {
            Rect bounds = (Rect)o;
            float x = UnityEngine.Random.value * bounds.width;
            float y = UnityEngine.Random.value * bounds.height;
            NextDestination = new Vector3(x, y, NextDestination.z);
        }

        return found;
    }


    public override nodeState Execute()
    {
        //If we have arriuved then find the next destination. 
        if ( Tree.transform.position == NextDestination )
        {
            if(!FindNextDestination())
            {
                return nodeState.FAILURE;
            }    
            else 
                return nodeState.SUCCESS;
        }
        else
        {
            Tree.gameObject.transform.position
                = Vector3.MoveTowards(Tree.gameObject.transform.position, NextDestination, Time.deltaTime * speed);

            return nodeState.SUCCESS;
        }
    }

}
