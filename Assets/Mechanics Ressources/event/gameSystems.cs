using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gameSystems : MonoBehaviour
{
    //GameObject[] triggers = new GameObject[5];

    public AudioClip[] dialogues = new AudioClip[5];

    public GameObject[] locations = new GameObject[5];

    public int arraySize = 5;
    public int cpt;

    public GameObject monster;

    private string coroutineName;
    // Start is called before the first frame update
    void Start()
    {
        coroutineName = "function" + cpt;
        //Debug.Log(coroutineName);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(("function1")());
    }

    

    public void testFunction()
    {
        monster.transform.position = locations[cpt].transform.position;
        Debug.Log("position du monstre : " + (cpt+1));
        //Debug.Log("dialogue n° " + (cpt +1) +" : "+ dialogues[cpt]);
        getExchange(cpt);

        cpt++;
        if (cpt >= arraySize)
        {
            cpt = 0;
        }

    }

    private void getExchange(int i)
    {
        coroutineName = "function" + i;
        StartCoroutine(coroutineName);

        
    }

    IEnumerator function0()
    {

        /*
        AudioClip.play
        soustitre.setText(tableau[ligne][langue]);
        
        Wait(AudioClip.isplaying == false)
        */

        Debug.Log("ligne 1");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 2");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 3");
        yield return new WaitForSeconds(1);

        yield return null;
    }

    IEnumerator function1()
    {
        Debug.Log("ligne 4");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 5");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 6");
        yield return new WaitForSeconds(1);

        yield return null;
    }
}
