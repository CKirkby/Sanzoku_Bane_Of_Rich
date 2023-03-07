using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PirateManager : MonoBehaviour
{
    [Header("Pirate Attributes")]
    [SerializeField] 
    internal float speed = 2f;
    [SerializeField]
    internal float damage = 50f;

    [Header("Script Refrences")]
    [SerializeField]
    internal PirateStateMachine pStateMachine;
    [SerializeField]
    internal PirateSearch pSearch;
    [SerializeField]
    internal PirateRandomLocation pRandomLocation;
    [SerializeField]
    internal PiratePatrol pPatrol;
    [SerializeField]
    internal PirateChase pChase;

    [Header("Element Refrences")]
    internal Animator pAnimator;
    [SerializeField]
    internal Transform player;
    [SerializeField]
    internal Transform enemy;

    private void Awake()
    {
        pAnimator = GetComponent<Animator>();
    }

}
