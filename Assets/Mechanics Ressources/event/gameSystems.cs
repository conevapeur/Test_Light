using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSystems : MonoBehaviour
{
    GameObject[] triggers = new GameObject[10];

    AudioClip[] dialogues = new AudioClip[20];

    GameObject[] locations = new GameObject[10];

    private int cpt;

    // Start is called before the first frame update
    void Start()
    {
        cpt = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        triggerEmit.OnTrigger += testFunction;
    }
    private void OnDisable()
    {
        triggerEmit.OnTrigger += testFunction;
    }

    private void testFunction()
    {
        Color col = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = col;
        Debug.Log(cpt);
        cpt++;
    }
}
