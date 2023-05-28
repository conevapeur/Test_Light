using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    private bool musicFadeOutEnabled = false;
    private bool musicFadeInEnabled = false;

    private void Awake()
    {
        AudioSource.Play();
        AudioSource.volume= 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicFadeInEnabled= true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicFadeOutEnabled= true;
        }
    }

    private void Update()
    {
        if (musicFadeOutEnabled)
        {

            float newVolume = AudioSource.volume - (0.1f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
            if (newVolume < 0f)
            {
                newVolume = 0f;
            }
            AudioSource.volume = newVolume;

        }

        if (musicFadeInEnabled)
        {
            float newVolume = AudioSource.volume + (0.1f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
            if (newVolume < 0f)
            {
                newVolume = 0f;
            }
            AudioSource.volume = newVolume;
        }

        if (AudioSource.volume == 0f)
        {
            musicFadeOutEnabled= false;
        }


        if (AudioSource.volume >= 0.1f)
        {
            musicFadeInEnabled = false;
        }
    }
}
