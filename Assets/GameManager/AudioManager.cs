using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
<<<<<<< HEAD
    [Header("Function Parameters")]
    [SerializeField] private bool useMusic = true;
    [SerializeField] private bool useAmbiance = true;

=======
>>>>>>> parent of af75d8c (Implementation of Health system UI and new map)
    [Header("Audio Parameters")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] ambianceCollection;
    [SerializeField] private AudioClip windWaterAmbiance;
    [SerializeField] private AudioClip attackClip;

    [Header("Refrences")]
    [SerializeField] private PirateFOV pFOV;


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        if (useMusic)
        Music();

        if (useAmbiance) 
            Ambiance();
=======
        if(pFOV.canSeePlayer== false)
        {
            m_AudioSource.PlayOneShot(ambianceCollection[Random.Range(0, ambianceCollection.Length - 1)]);
        }
>>>>>>> parent of af75d8c (Implementation of Health system UI and new map)
    }

    // Update is called once per frame
    void Update()
    {
      /*  while(pFOV.canSeePlayer == true)
        {
            m_AudioSource.PlayOneShot(attackClip);
        } */
<<<<<<< HEAD
    }

    private void Music()
    {
        m_AudioSource.PlayOneShot(ambianceCollection[Random.Range(0, ambianceCollection.Length - 1)]);
    }

    private void Ambiance()
    {
        m_AudioSource.volume = 0.5f;
        m_AudioSource.PlayOneShot(windWaterAmbiance);
    }
=======
    } 
>>>>>>> parent of af75d8c (Implementation of Health system UI and new map)
}
