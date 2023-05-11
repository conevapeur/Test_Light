using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    /////////////////////// Game
    public int progression;
    public Vector3 lastCheckpoint;

    public string coroutineName;


    public GameObject player;
    

    
    public GameObject talkie;

    public int frequenceP = 0;
    public int frequenceM;

    ////////////////////////// Monster
    public GameObject monster;

    public GameObject[] locations = new GameObject[8];
    public float distancePM;
    public float navDistancePM;


    public TMP_Text soustitres;




    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        progression = 0;
        coroutineName = "function" + progression;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region frequences
    public void UpFreq()
    {
        //Debug.Log("up");

        frequenceP += 1;
        frequenceP = frequenceP % 5;

        talkie.GetComponent<talkie>().refreshFreq(frequenceP);
        talkie.GetComponent<talkie>()._animator.SetTrigger("trigger");
    }

    public void DownFreq()
    {
        //Debug.Log("down");

        frequenceP -= 1;
        if (frequenceP < 0)
            frequenceP = 4;

        talkie.GetComponent<talkie>().refreshFreq(frequenceP);
        talkie.GetComponent<talkie>()._animator.SetTrigger("trigger");
    }

    #endregion


    #region dialogues
    public void Progress()
    {
        monster.transform.position = locations[progression].transform.position;
        //Debug.Log("position du monstre : " + (cpt+1));
        //Debug.Log("dialogue n° " + (cpt +1) +" : "+ dialogues[cpt]);
        getDialogue(progression);

        Debug.Log("echange numéro : " + (progression + 1));

        progression++;
        if (progression >= locations.Length)
        {
            progression = 0;
        }
    }

    private void getDialogue(int _progression)
    {
        coroutineName = "function" + _progression;
        StartCoroutine(coroutineName);
    }


    #endregion
}
