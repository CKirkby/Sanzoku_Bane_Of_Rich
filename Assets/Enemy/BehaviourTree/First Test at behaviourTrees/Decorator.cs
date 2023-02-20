using System;
using UnityEngine;

public class Decorator : BTnode
{

    //Decorators are what alter the states.
    
   public BTnode Child { get; set; }
    public Decorator( BehaviourTree t, BTnode c) : base(t)
    {
        Child = c;
    }



}
