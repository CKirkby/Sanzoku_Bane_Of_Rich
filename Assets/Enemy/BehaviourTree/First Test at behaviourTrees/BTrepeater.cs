using System;
using UnityEngine;

public class BTrepeater : Decorator
{
    public BTrepeater(BehaviourTree t, BTnode c) : base(t, c)
    {

    }

    public override nodeState Execute()
    {
        Debug.Log ("Child Returned" + Child.Execute());
        return nodeState.RUNNING;
    }
}
