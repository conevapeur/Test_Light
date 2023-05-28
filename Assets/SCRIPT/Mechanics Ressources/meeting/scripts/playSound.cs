using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip myClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAudioSource.clip = myClip;
            myAudioSource.Play();
            //Destroy(this);
            Debug.Log("blass sound");
        }
    }
}
