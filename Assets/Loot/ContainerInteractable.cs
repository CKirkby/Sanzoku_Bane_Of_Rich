 using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ContainerInteractable : Interactable
{

    [Header("Audio Parameters")]
    [SerializeField] private AudioSource _audioSource;
    public AudioSource crashAudioClip;

    [Header("Refrences")]
    [SerializeField] private Material originalMat;

    [Header("Whole Create")]
    public MeshRenderer wholeCrate;
    public BoxCollider boxCollider;

    [Header("Fractured Create")]
    public GameObject fracturedCrate;


    public override void OnFocus()
    {
        Renderer.material.color = Color.yellow;
    }

    public override void OnInteract()
    {
        wholeCrate.enabled = false;
        boxCollider.enabled = false;
        fracturedCrate.SetActive(true);
        crashAudioClip.Play();
    }

    public override void OnLoseFocus()
    {
        Renderer.material = originalMat;
    }
}
