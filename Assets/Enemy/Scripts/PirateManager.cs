using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PirateManager : MonoBehaviour
{
    [Header("Pirate Attributes")]
    [SerializeField]
    internal float damage = 50f;

    [Header("Audio Properties")]
    [SerializeField] internal AudioSource pAudioSource;
    [SerializeField] internal AudioClip[] pWarCry;

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
    internal PirateFOV pFOV;
    [SerializeField]
    internal NavMeshAgent navMeshAgent;

    [Header("Element Refrences")]
    internal Animator pAnimator;
    [SerializeField]
    internal GameObject player;
    [SerializeField]
    internal Transform enemy;

    internal void Awake()
    {
        pAnimator = GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        pAudioSource = GetComponent<AudioSource>();
    }
}
