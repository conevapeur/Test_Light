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

        if (dist < 3)
        {
            gameObject.GetComponent<Image>().enabled = true;
            if (dist < 1.5)
            {
                animator.SetBool("trigger", true);
                //Debug.Log("chien mou");
            }
            if (dist >= 1.5)
            {
                animator.SetBool("trigger", false);
            }
        }
        else       
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
        
    }
}