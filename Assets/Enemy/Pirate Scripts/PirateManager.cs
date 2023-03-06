using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Element Refrences")]
    internal Animator pAnimator;

    private void Awake()
    {
        pAnimator = GetComponent<Animator>();0.3
    }

}
