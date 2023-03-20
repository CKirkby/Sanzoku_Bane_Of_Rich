using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public MeshRenderer Renderer;

    public virtual void Awake()
    {
        gameObject.layer = 11;
        Renderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
}
