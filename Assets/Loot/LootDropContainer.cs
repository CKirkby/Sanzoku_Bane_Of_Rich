using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropContainer : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsToDrop;
    [SerializeField] private Transform itemSpawnPoint;

    public void LootDrop()
    {
        Instantiate(itemsToDrop[Random.Range(1, 2)], itemSpawnPoint);
    }
}
