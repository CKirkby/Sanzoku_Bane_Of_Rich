 using System.Collections;
using UnityEngine;

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
        //Changes colour to yellow when looking at item.
        Renderer.material.color = Color.yellow;
    }

    public override void OnInteract()
    {
        //On interact, disables the full prefab for the crate and activates the broken one to stimulate breaking open a crate and then plays audio to match. 
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
        //When looks away Gives the material its original colour back.
        Renderer.material = originalMat;
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7);

        Destroy(gameObject);
    }
}
