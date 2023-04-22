using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawnerCourtyardCrates : MonoBehaviour
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
        while (numOfSpawns < 50)
        {
            xPos = Random.Range(3, 6);
            zPos = Random.Range(23, 23);

            //Spawns the loot within given vectors of main map. 
            Instantiate(loot[randomLoot], new Vector3(xPos, 0.32f, zPos), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
            numOfSpawns += 1;

        }
    }
}