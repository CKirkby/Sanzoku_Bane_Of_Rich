using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject npc;
    public int xPos;
    public int zPos;
    private int numOfSpawns = 0;

    private void Start()
    {
        StartCoroutine(NpcSpawnerFunction());
    }

    IEnumerator NpcSpawnerFunction()
    {
        // If the number of spawns are less then 30, will generate a random position based on given values and instantiate the prefab every 0.1 second.
        while (numOfSpawns < 30)
        {
            xPos = Random.Range(-80, 37);
            zPos = Random.Range(-3, 4);

            //Spawns the npc within given vectors of main map. 
            Instantiate(npc, new Vector3(xPos, 0.01f, zPos), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
            numOfSpawns += 1;

        }
    }
}
