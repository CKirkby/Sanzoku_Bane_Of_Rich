using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ContainerInteractable : Interactable
{

    [Header("Audio Parameters")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip openBox;

    [Header("Refrences")]
    [SerializeField] private Material originalMat;
    

    public override void OnFocus()
    {
        Renderer.material.color = Color.yellow;
    }

    public override void OnInteract()
    {
        _audioSource.PlayOneShot(openBox);
    }

    public override void OnLoseFocus()
    {
        Renderer.material = originalMat;
    }
}
