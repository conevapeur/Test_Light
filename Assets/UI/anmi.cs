using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class anmi : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField] private Animator animator;


    // Update is called once per frame
    void Update()
    {


        var dist = Vector3.Distance(target.position, transform.position);
        if (dist < 2)
        {
            animator.SetTrigger("isActivated");
        }
        if (dist >= 2)
        {
            animator.SetTrigger("isDesactivated");
        }
        
    }
}