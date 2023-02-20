using System.Collections;
using System.Collections.Generic;

public class BTSequencer : BTComposite
{

    private int currentNode = 0;


    public BTSequencer(BehaviourTree t, BTnode [] children) : base(t, children)
    {

    }



    //Asking if all returned successful. If it did then it is sucessful.
    // If not will return false if any return false.
    public override nodeState Execute()
    {
        if (currentNode < Children.Count)
        {
            nodeState state = Children[currentNode].Execute();

            if (state == nodeState.RUNNING)
                return nodeState.RUNNING;
            else if (state == nodeState.FAILURE)
            {
                currentNode = 0;
                return nodeState.FAILURE;
            }
            else
            {
                currentNode++;
                if (currentNode < Children.Count)
                    return nodeState.RUNNING;
                else
                {
                    currentNode = 0;
                    return nodeState.SUCCESS;
                }
            }
           
        }

        return nodeState.SUCCESS;
    }

}
