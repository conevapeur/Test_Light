using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEmit : MonoBehaviour
{
    public delegate void TrigerAction();
    public static event TrigerAction OnTrigger;



    GameObject[] triggers = new GameObject[10];

    AudioClip[] dialogues = new AudioClip[20];

    GameObject[] locations = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            OnTrigger();
        }
    }
}
