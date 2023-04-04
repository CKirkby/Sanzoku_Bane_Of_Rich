using System.Collections;
using UnityEngine;

public class SpawnGizmos : MonoBehaviour
{
    public GameObject itemToSpawn;
    public int numSpawns = 1;

    public Vector3 centre;
    public Vector3 size;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numSpawns; i++)
        {
            SpawnItem();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(size.x, size.y, size.z));
    }
    private void SpawnItem()
    {
        Vector3 position = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2));

        GameObject spawnedObject = Instantiate(itemToSpawn, position, Quaternion.identity);

        Rigidbody rigidbody = spawnedObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            float speed = 5f;
            rigidbody.velocity = Random.onUnitSphere * speed;
        }
    }

}