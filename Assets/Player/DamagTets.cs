using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagTets : MonoBehaviour
{
    public PlayerHealth pHealh;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            pHealh.ApplyDamage(25);
    }


}
