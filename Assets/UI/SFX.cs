using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] AudioSource sound;

    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(UIStart.ENG)
            {
                sound.clip = clip1;
            }
            else
            {
                sound.clip = clip2;
            }
            sound.Play();

        }
    }
}
