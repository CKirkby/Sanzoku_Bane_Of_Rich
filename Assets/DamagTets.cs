using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagTets : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PlayerHealth.OnTakeDamage(15);
    }


}
