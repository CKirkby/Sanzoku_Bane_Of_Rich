using System.Collections;
using UnityEngine;

public class CoinPickup: Interactable
{
    [Header("Refrences")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] audioCollection;
    [SerializeField] private Material originalMat;
    public PlayerInventory pInventory;

    [Header("Coin Properties")]
    [SerializeField] private float value = 5;

    private void Start()
    {
        pInventory = Component.FindObjectOfType<PlayerInventory>();
    }

    public override void OnFocus()
    {
        //Changes colour to yellow when looking at item.
        Renderer.material.color = Color.yellow;
    }

    public override void OnInteract()
    {
        //Picks up the item, plays a coin sound and then adds the value to the player score. 
        _audioSource.PlayOneShot(audioCollection[Random.Range(0, audioCollection.Length - 1)]);
        pInventory.score += value;
        StartCoroutine(WaitForSecs());
    }

    public override void OnLoseFocus()
    {
        //When looks away Gives the material its original colour back.
        Renderer.material = originalMat;
    }

    private IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
