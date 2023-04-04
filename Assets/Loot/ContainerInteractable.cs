 using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ContainerInteractable : Interactable
{

    [Header("Audio Parameters")]
    [SerializeField] private AudioSource _audioSource;
    public AudioSource crashAudioClip;

    [Header("LootSplosion Parameters")]
    [SerializeField] private GameObject[] lootObjects;

    [Header("Refrences")]
    [SerializeField] private Material originalMat;
    public MeshRenderer wholeCrate;
    public BoxCollider boxCollider;
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
        StartCoroutine(Destroy());
    
    }

    public override void OnLoseFocus()
    {
        Renderer.material = originalMat;
    }

    //CREATE A LOOTSPLOSION

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7);

        Destroy(gameObject);
    }
}
