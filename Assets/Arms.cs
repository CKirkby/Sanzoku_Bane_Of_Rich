using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Arms : MonoBehaviour
{
    public Animator animator;
    public PlayerInput playerInput;
    public StarterAssetsInputs _input;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponentInParent<PlayerInput>();
        _input = GetComponentInParent<StarterAssetsInputs>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Grab();

    }

    public void Grab()
    {
        if(_input.grab)
        {
            animator.SetBool("isGrabbing", true);
            Debug.Log("PICKING UP");
        }
        else
        {
            animator.SetBool("isGrabbing", false);
        }

    }
    
}
