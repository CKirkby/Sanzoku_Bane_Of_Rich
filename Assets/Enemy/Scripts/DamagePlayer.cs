using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private GameObject swordPoint;
    [SerializeField] private float damage;
    public PlayerHealth pHealth;

    // Start is called before the first frame update
    void Start()
    {
        damage = 50;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        pHealth.ApplyDamage(damage);
    }

}
