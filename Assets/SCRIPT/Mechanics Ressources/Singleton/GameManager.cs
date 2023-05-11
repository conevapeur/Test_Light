using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject player;
    
    
    public GameObject talkie;

    [SerializeField] int frequenceM;
    [SerializeField] int frequencep;

    ////////////////////////// Monster
    public GameObject monster;

    public GameObject[] locations = new GameObject[8];



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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
