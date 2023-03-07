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

    private void Update()
    {
      if(_input.grab)
        {
            StartCoroutine(Grab());
        }
    }

    private IEnumerator Grab()
    {
        animator.SetBool("isGrabbing", true);
        Debug.Log("PICKING UP");
        

        yield return new WaitForSeconds(2);

        animator.SetBool("isGrabbing" ,false);
        Debug.Log("Resetting arm");
    }
    
}
