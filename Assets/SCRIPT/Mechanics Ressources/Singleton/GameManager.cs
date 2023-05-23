using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.AI;

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


    [SerializeField] GameObject firstRoom;
    [SerializeField] GameObject secondRoom;
    [SerializeField] GameObject couloirRoom;

    public GameObject Caller;

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
        //progression = 0;
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


    #region progression
    public void Progress()
    {
        monster.GetComponent<NavMeshAgent>().enabled = false;
        monster.transform.position = locations[progression].transform.position;
        monster.GetComponent<NavMeshAgent>().enabled = true;
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
        if(progression > 0)
            player.GetComponent<FPC>().haveToDegaine = true;
        StartCoroutine(coroutineName);
    }


    #endregion

    #region dialogues

    IEnumerator function0()
    {
        talkie.GetComponent<talkie>().curFreq = talkie.GetComponent<talkie>().state;
        player.GetComponent<FPC>().lockAbilities("listening");
        player.GetComponent<FPC>().animator.SetTrigger("triggerTalk");
            
        /*
        AudioClip.play
        soustitre.setText(tableau[ligne][langue]);
        
        Wait(AudioClip.isplaying == false)
        */

        Debug.Log("ligne 1");
        soustitres.SetText("Papa je suis tombée dans un trou, je peux pas sortir.");
        //audioSource.clip = audioClip;
        //audioSource.Play();

        yield return new WaitForSeconds(2);
        Debug.Log("ligne 2");
        soustitres.SetText("Dans un trou? Qu'est ce que tu vois?");
        //audioSource.Play();

        yield return new WaitForSeconds(3);
        Debug.Log("ligne 3");
        soustitres.SetText("Y a une grande porte, toute vieille avec des cailloux.");
        //audioSource.Play();

        yield return new WaitForSeconds(4);
        Debug.Log("ligne 4");
        soustitres.SetText("Est ce qu'il y a marqué quelque chose sur la porte?");
        //audioSource.Play();

        yield return new WaitForSeconds(4);
        Debug.Log("ligne 5");
        soustitres.SetText("Oui, y a marqué B-SKY-19 dessus.");
        //audioSource.Play();

        yield return new WaitForSeconds(4);

        player.GetComponent<FPC>().recover();


        Debug.Log("ligne 6");
        soustitres.SetText("Ok, je connais cet endroit. Je travaillais là avant. Ne t'inquiètes pas. Si la porte est fermée devant toi, tu devrais apercevoir un conduit d’aération sur la droite. Passe-y.");
        //audioSource.Play();

        yield return new WaitForSeconds(7);
        soustitres.SetText(" ");
        //player.GetComponent<FPC>().haveToDegaine = true;
        player.GetComponent<FPC>().animator.SetTrigger("triggerEndTalk");
        yield return null;
    }

    IEnumerator function1()
    {
        talkie.GetComponent<talkie>().curFreq = 3;
        player.GetComponent<FPC>().lockAbilities("listening");

        Debug.Log("ligne 7");
        soustitres.SetText("J’y suis papa, je fais quoi maintenant?");
        yield return new WaitForSeconds(1);

        /*
        Debug.Log("ligne 8");
        soustitres.SetText("(voix grésillante) passe par la porte et suit le couloir.");
        yield return new WaitForSeconds(1);
        */

        Debug.Log("ligne 9");
        soustitres.SetText("Je t'entends pas papa.");
        yield return new WaitForSeconds(1);


        while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
        {
            Debug.Log("audio parasite");
            yield return new WaitForSeconds(2);
        }

        player.GetComponent<FPC>().recover();

        Debug.Log("ligne 10");
        soustitres.SetText("Passe par la porte de la réserve, une fois sortie, tu vas te retrouver à l’accueil. Continue le couloir et tu devrais arriver au niveau inférieur");
        yield return new WaitForSeconds(1);


        soustitres.SetText(" ");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }

    IEnumerator function2()
    {
        talkie.GetComponent<talkie>().curFreq = 1;
        player.GetComponent<FPC>().lockAbilities("listening");
        Debug.Log("ligne 11");
        soustitres.SetText("Papa, la porte est fermée, je fais quoi?");
        yield return new WaitForSeconds(1);

        while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
        {
            Debug.Log("audio parasite");
            yield return new WaitForSeconds(2);
        }
        player.GetComponent<FPC>().recover();
        Debug.Log("ligne 12");
        soustitres.SetText("l'électricité...  il faut que tu remettes l’électricité. Le générateur de secours devrait être dans une salle à gauche.Tu n'auras qu'à abaisser le levier et ça devrait marcher.");
        yield return new WaitForSeconds(1);
        soustitres.SetText(" ");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }
    IEnumerator function3()
    {
        talkie.GetComponent<talkie>().curFreq = 4;
        player.GetComponent<FPC>().lockAbilities("listening");
        Debug.Log("ligne 13");
        soustitres.SetText("Y a quelque chose qui bloque derrière la porte. J'peux pas l'ouvrir.");
        yield return new WaitForSeconds(1);

        while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
        {
            Debug.Log("audio parasite");
            yield return new WaitForSeconds(2);
        }
        player.GetComponent<FPC>().recover();
        Debug.Log("ligne 14");
        soustitres.SetText("Trouve un moyen de passer au-dessus. Prends une chaise ou un objet pour escalader.");
        yield return new WaitForSeconds(1);
        soustitres.SetText(" ");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }
    IEnumerator function4()
    {
        Debug.Log("ligne 15");
        soustitres.SetText("Je suis passée papa");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 16");
        soustitres.SetText("Continue, le générateur est en bas de l’escalier. Pour l’actionner, tire le levier vers le bas.");
        yield return new WaitForSeconds(1);
        soustitres.SetText(" ");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }

    IEnumerator function5()
    {
        player.GetComponent<FPC>().lockAbilities("listening");

        Debug.Log("ligne 17");
        soustitres.SetText("Papa, t’es sûr que c’est le bon chemin, les escaliers sont cassés, on ne pourra pas revenir par là.");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 18");
        soustitres.SetText("Oui, il y a une autre sortie de l'autre côté, on sortira par là.");
        yield return new WaitForSeconds(1);

        
        player.GetComponent<FPC>().recover();
        
        Debug.Log("ligne 19");
        soustitres.SetText("Ok, je descends alors");
        yield return new WaitForSeconds(1);
        soustitres.SetText(" ");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }
    IEnumerator function6()
    {
        Debug.Log("ligne 20");
        soustitres.SetText("Je suis arrivée dans un couloir je vais où maintenant?");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 21");
        soustitres.SetText("Tu dois avoir la salle de contrôle devant toi. Tu as besoin de la carte d'accès pour ouvrir cette pièce. Il doit y avoir mon ancienne carte dans mon bureau. Il y a une carte de secours derrière le tableau avec les oiseaux. Trouve la et reviens ici. ");
        yield return new WaitForSeconds(1);
        soustitres.SetText(" ");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }
    IEnumerator function7()
    {
        Debug.Log("ligne 22");
        soustitres.SetText("Je rentre dans la salle papa.");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 23");
        soustitres.SetText("Tu vois le bouton rouge? appuie dessus. ");
        yield return new WaitForSeconds(1);
        soustitres.SetText(" ");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }

    #endregion

    #region meetings
    public void LanceMeeting2Points()
    {
        progression = 10;
        StartCoroutine(Meeting2Points());
    }
    public IEnumerator Meeting2Points()
    {
        Transform start = null;
        Transform point = null;

        if(Caller.TryGetComponent<firstRoomTrigger>(out firstRoomTrigger script))
        {
            start = script.start.transform;
            point = script.point.transform;
        }

        else if (Caller.TryGetComponent<debrisVerre>(out debrisVerre _script))
        {
            start = _script.start.transform;
            point = _script.point.transform;
        }

        monster.GetComponent<NavMeshAgent>().enabled = false;
        //monster.transform.position = firstRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        monster.transform.position = start.position;
        monster.GetComponent<NavMeshAgent>().enabled = true;


        //monster.GetComponent<NavMeshAgent>().destination = firstRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        monster.GetComponent<NavMeshAgent>().destination = start.position;
        yield return new WaitForSeconds(5);


        //monster.GetComponent<NavMeshAgent>().destination = firstRoom.GetComponent<firstRoomTrigger>().point.transform.position;
        //monster.GetComponent<NavMeshAgent>().destination = player.transform.position;
        monster.GetComponent<NavMeshAgent>().destination = point.position;
        yield return new WaitForSeconds(5);


        //monster.GetComponent<NavMeshAgent>().destination = firstRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        monster.GetComponent<NavMeshAgent>().destination = start.position;
        yield return new WaitForSeconds(5);


        monster.GetComponent<NavMeshAgent>().enabled = false;
        monster.transform.position = locations[0].transform.position;
        monster.GetComponent<NavMeshAgent>().enabled = true;

        yield return null;
    }


    public void lanceMeeting2()
    {
        progression = 10;
        StartCoroutine(Meeting2());
    }
    public IEnumerator Meeting2()
    {
        monster.GetComponent<NavMeshAgent>().enabled = false;
        monster.transform.position = secondRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        monster.GetComponent<NavMeshAgent>().enabled = true;


        monster.GetComponent<NavMeshAgent>().destination = secondRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        yield return new WaitForSeconds(5);


        monster.GetComponent<NavMeshAgent>().destination = secondRoom.GetComponent<firstRoomTrigger>().point.transform.position;
        //monster.GetComponent<NavMeshAgent>().destination = player.transform.position;
        yield return new WaitForSeconds(5);


        monster.GetComponent<NavMeshAgent>().destination = secondRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        yield return new WaitForSeconds(5);


        monster.GetComponent<NavMeshAgent>().enabled = false;
        monster.transform.position = locations[0].transform.position;
        monster.GetComponent<NavMeshAgent>().enabled = true;

        yield return null;
    }

    public void lanceMeeting3()
    {
        progression = 10;
        StartCoroutine(Meeting3());
    }
    public IEnumerator Meeting3()
    {
        monster.GetComponent<NavMeshAgent>().enabled = false;
        monster.transform.position = couloirRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        monster.GetComponent<NavMeshAgent>().enabled = true;


        monster.GetComponent<NavMeshAgent>().destination = couloirRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        yield return new WaitForSeconds(5);


        monster.GetComponent<NavMeshAgent>().destination = couloirRoom.GetComponent<firstRoomTrigger>().point.transform.position;
        //monster.GetComponent<NavMeshAgent>().destination = player.transform.position;
        yield return new WaitForSeconds(5);


        monster.GetComponent<NavMeshAgent>().destination = couloirRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        yield return new WaitForSeconds(5);


        monster.GetComponent<NavMeshAgent>().enabled = false;
        monster.transform.position = locations[0].transform.position;
        monster.GetComponent<NavMeshAgent>().enabled = true;

        yield return null;
    }

    #endregion
}
