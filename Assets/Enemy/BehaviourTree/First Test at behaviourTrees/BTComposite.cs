using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTComposite : BTnode
{

    public List<BTnode> Children { get; set; }

    public BTComposite(BehaviourTree t, BTnode [] nodes) : base(t)
    {
        //Contructs a new list out of the array above.
        Children = new List<BTnode>(nodes);
    }


}
