using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner1 : MonoBehaviour
{
    public GameObject[] loot;
    public int randomLoot;
    public int xPos;
    public int zPos;
    private int numOfSpawns = 0;

    private void Start()
    {
        StartCoroutine(LootSpawnerFunction());
    }

    IEnumerator LootSpawnerFunction()
    {
        randomLoot = Random.Range(0, loot.Length);
        while (numOfSpawns < 40)
        {
            xPos = Random.Range(1, 23);
            zPos = Random.Range(8, 12);

            //Spawns the loot within given vectors of main map. 
            Instantiate(loot[randomLoot], new Vector3(xPos, 0.01f, zPos), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
            numOfSpawns += 1;

        }
    }
}