using System.Collections;
using UnityEngine;

public class CoinPickup: Interactable
{
    [Header("Refrences")]
    public PlayerInventory pInventory;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] audioCollection;

    [Header("Coin Properties")]
    [SerializeField] private float value = 5;

    public override void OnFocus()
    {
        Renderer.material.color = Color.yellow;
    }

    public override void OnInteract()
    {
        _audioSource.PlayOneShot(audioCollection[Random.Range(0, audioCollection.Length - 1)]);
        pInventory.score += value;
        Destroy(gameObject);
    }

    public override void OnLoseFocus()
    {
        Renderer.material.color = Color.gray;
    }
<<<<<<< HEAD

    private IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(0.19f);
        Destroy(gameObject);
    }
=======
>>>>>>> parent of af75d8c (Implementation of Health system UI and new map)
}
