using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class interactButton : MonoBehaviour, IInteract
{
    [SerializeField] private Animator _archives;
   
    [SerializeField] private Animator _bureau2;
    [SerializeField] private GameObject _redLigths;

    [SerializeField] private GameObject objet1;
    [SerializeField] private GameObject objet2;

    [SerializeField] AudioSource sound;
    [SerializeField] AudioClip clip1;
    [SerializeField] private AudioClip clip2;
    private void Start()
    {
        _redLigths.gameObject.SetActive(false);
        objet2.SetActive(false);
    }
    public void OnInteract()
    {
        _redLigths.gameObject.SetActive(true);
        _archives.SetTrigger("trigger");
        
        _bureau2.SetTrigger("trigger");

        objet2.SetActive(true);
        objet1.SetActive(false);



        if (UIStart.ENG)
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
