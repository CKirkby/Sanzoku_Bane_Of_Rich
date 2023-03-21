using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Parameters")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] ambianceCollection;
    [SerializeField] private AudioClip attackClip;

    [Header("Refrences")]
    [SerializeField] private PirateFOV pFOV;


    // Start is called before the first frame update
    void Start()
    {
        if(pFOV.canSeePlayer== false)
        {
            m_AudioSource.PlayOneShot(ambianceCollection[Random.Range(0, ambianceCollection.Length - 1)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
      /*  while(pFOV.canSeePlayer == true)
        {
            m_AudioSource.PlayOneShot(attackClip);
        } */
    } 
}
