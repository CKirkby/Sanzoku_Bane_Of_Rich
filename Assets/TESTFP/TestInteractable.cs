using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{
    public override void OnFocus()
    {
        Debug.Log("LOOKING AT" + gameObject.name);
        Renderer.material.color = Color.black;
    }

    public override void OnInteract()
    {
        Debug.Log("INTERACTED WITH" + gameObject.name);
        Destroy(gameObject);
    }

    public override void OnLoseFocus()
    {
        Debug.Log("STOPPED LOOKING AT" + gameObject.name);
        Renderer.material.color = Color.white;
    }
}
