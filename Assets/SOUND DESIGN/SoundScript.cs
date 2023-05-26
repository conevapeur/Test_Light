using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.Play();
            Destroy(this);
        }
    }
}
