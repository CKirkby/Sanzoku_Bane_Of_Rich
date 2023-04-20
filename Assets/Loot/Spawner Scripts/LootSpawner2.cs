using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner2 : MonoBehaviour
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
        //Genereates loot prefabs, based on the given X and Y positions. 
        randomLoot = Random.Range(0, loot.Length);
        while (numOfSpawns < 25)
        {
            xPos = Random.Range(22, 24);
            zPos = Random.Range(7, 9);

            //Spawns the loot within given vectors of main map. 
            Instantiate(loot[randomLoot], new Vector3(xPos, 1, zPos), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
            numOfSpawns += 1;

        }
    }
}