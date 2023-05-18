using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CineManager : MonoBehaviour
{


    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.SetTrigger("triggercine");
    }


    
}
