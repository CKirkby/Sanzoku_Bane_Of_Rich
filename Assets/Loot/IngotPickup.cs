using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IngotPickup: Interactable
{
    [Header("Refrences")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] audioCollection;
    public PlayerInventory pInventory;

    [Header("Coin Properties")]
    [SerializeField] private float value = 50;

    public override void OnFocus()
    {
        Renderer.material.color = Color.yellow;
    }

    public override void OnInteract()
    {
        _audioSource.PlayOneShot(audioCollection[Random.Range(0, audioCollection.Length - 1)]);
        pInventory.score = pInventory.score + value;
        StartCoroutine(WaitForSecs());
    }

    public override void OnLoseFocus()
    {
        Renderer.material.color = default(Color);
    }

    private IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
