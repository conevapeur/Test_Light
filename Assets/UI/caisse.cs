using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caisse : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && interactReadable.card)
        {
            animator.SetTrigger("trigger");
            //audioSource.Play();
            Destroy(this);
        }
    }
}

