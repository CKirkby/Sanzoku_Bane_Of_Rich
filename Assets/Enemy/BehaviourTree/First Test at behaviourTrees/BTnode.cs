using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTnode
{

    //Defines the three states needed for a tree
    public enum nodeState { RUNNING, FAILURE, SUCCESS };


    public BehaviourTree Tree { get; set; }

    public BTnode(BehaviourTree t)
    {
        Tree = t;
    }


    public virtual nodeState Execute()
    {
        //Return failure by default. Inheriting from btnode. 
        return nodeState.FAILURE;
    }

}


