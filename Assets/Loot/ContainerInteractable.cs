 using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class ContainerInteractable : Interactable
{

    [Header("Audio Parameters")]
    [SerializeField] private AudioSource crashAudioClip;
    [SerializeField] private AudioClip[] coinCollection;

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
        //ldCont.LootDrop();
        crashAudioClip.PlayOneShot(coinCollection[Random.Range(0, coinCollection.Length - 1)]);
        StartCoroutine(Destroy());
    }

    public override void OnLoseFocus()
    {
        Renderer.material = originalMat;
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7);

        Destroy(gameObject);
    }
}
