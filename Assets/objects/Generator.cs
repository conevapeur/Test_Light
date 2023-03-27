using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //switch lightmaps
    // anim

    [SerializeField] Transform target;
    [SerializeField] Animator animator;
    private bool closeEnough;

    private UI controls;

    private void Awake()
    {
        controls = new UI();
        controls.ActionTest.interact.performed += ctx =>Interact();
    }

    private void Update()
    {
        var dist = Vector3.Distance(target.position, transform.position);
        if (dist < 2.5 ) 
        { 
            closeEnough = true;
        }
    }
    private void OnEnable()
    {
        controls.ActionTest.Enable();
    }
    private void OnDisable()
    {
        controls.ActionTest.Disable();
    }
    private void Interact()
    {
        if ( closeEnough == true )
        {
            Debug.Log("chien");
            animator.SetTrigger("isActivated");
        }
    }
}
