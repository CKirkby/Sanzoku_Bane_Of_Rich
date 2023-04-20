using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public MeshRenderer Renderer;

    public virtual void Awake()
    {
        gameObject.layer = 11;
        Renderer = gameObject.GetComponent<MeshRenderer>();
    }
    //Classes that interactable objects will be able to inherit to allow them some form of function. 
    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
}
