using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PirateChase : MonoBehaviour
{
    [SerializeField]
    internal PirateManager pManager;

    [Header("Player refrences")]
    internal float distPlayer;
    internal bool playerSeen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distPlayer = Vector3.Distance(pManager.enemy.transform.position, pManager.player.transform.position);
    }
}
