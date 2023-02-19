using System;
using UnityEngine;

public class Decorator : BTnode
{

    //Decorators are what alter the states.
    
    BTnode Child { get; set; }
    public Decorator( BehaviourTree t, BTnode c) : base(t)
    {
        Child = c;
    }



}
