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
            Destroy(gameObject);    // Suppression d'une instance pr�c�dente

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
        //Debug.Log("dialogue n� " + (cpt +1) +" : "+ dialogues[cpt]);
        getDialogue(progression);

        Debug.Log("echange num�ro : " + (progression + 1));

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
        soustitres.SetText("Papa je suis tomb�e dans un trou, je peux pas sortir.");
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
        soustitres.SetText("Est ce qu'il y a marqu� quelque chose sur la porte?");
        //audioSource.Play();

        yield return new WaitForSeconds(4);
        Debug.Log("ligne 5");
        soustitres.SetText("Oui, y a marqu� B-SKY-19 dessus.");
        //audioSource.Play();

        yield return new WaitForSeconds(4);

        player.GetComponent<FPC>().recover();


        Debug.Log("ligne 6");
        soustitres.SetText("Ok, je connais cet endroit. Je travaillais l� avant. Ne t'inqui�tes pas. Si la porte est ferm�e devant toi, tu devrais apercevoir un conduit d�a�ration sur la droite. Passe-y.");
        //audioSource.Play();

        yield return new WaitForSeconds(7);
        soustitres.SetText("�");
        //player.GetComponent<FPC>().haveToDegaine = true;
        player.GetComponent<FPC>().animator.SetTrigger("triggerEndTalk");
        yield return null;
    }

    IEnumerator function1()
    {
        talkie.GetComponent<talkie>().curFreq = 3;
        player.GetComponent<FPC>().lockAbilities("listening");

        Debug.Log("ligne 7");
        soustitres.SetText("J�y suis papa, je fais quoi maintenant?");
        yield return new WaitForSeconds(1);

        /*
        Debug.Log("ligne 8");
        soustitres.SetText("(voix gr�sillante) passe par la porte et suit le couloir.");
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
        soustitres.SetText("Passe par la porte de la r�serve, une fois sortie, tu vas te retrouver � l�accueil. Continue le couloir et tu devrais arriver au niveau inf�rieur");
        yield return new WaitForSeconds(1);


        soustitres.SetText("�");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }

    IEnumerator function2()
    {
        talkie.GetComponent<talkie>().curFreq = 1;
        player.GetComponent<FPC>().lockAbilities("listening");
        Debug.Log("ligne 11");
        soustitres.SetText("Papa, la porte est ferm�e, je fais quoi?");
        yield return new WaitForSeconds(1);

        while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
        {
            Debug.Log("audio parasite");
            yield return new WaitForSeconds(2);
        }
        player.GetComponent<FPC>().recover();
        Debug.Log("ligne 12");
        soustitres.SetText("l'�lectricit�...  il faut que tu remettes l��lectricit�. Le g�n�rateur de secours devrait �tre dans une salle � gauche.Tu n'auras qu'� abaisser le levier et �a devrait marcher.");
        yield return new WaitForSeconds(1);
        soustitres.SetText("�");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }
    IEnumerator function3()
    {
        talkie.GetComponent<talkie>().curFreq = 4;
        player.GetComponent<FPC>().lockAbilities("listening");
        Debug.Log("ligne 13");
        soustitres.SetText("Y a quelque chose qui bloque derri�re la porte. J'peux pas l'ouvrir.");
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
        soustitres.SetText("�");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }
    IEnumerator function4()
    {
        Debug.Log("ligne 15");
        soustitres.SetText("Je suis pass�e papa");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 16");
        soustitres.SetText("Continue, le g�n�rateur est en bas de l�escalier. Pour l�actionner, tire le levier vers le bas.");
        yield return new WaitForSeconds(1);
        soustitres.SetText("�");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }

    IEnumerator function5()
    {
        player.GetComponent<FPC>().lockAbilities("listening");

        Debug.Log("ligne 17");
        soustitres.SetText("Papa, t�es s�r que c�est le bon chemin, les escaliers sont cass�s, on ne pourra pas revenir par l�.");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 18");
        soustitres.SetText("Oui, il y a une autre sortie de l'autre c�t�, on sortira par l�.");
        yield return new WaitForSeconds(1);

        
        player.GetComponent<FPC>().recover();
        
        Debug.Log("ligne 19");
        soustitres.SetText("Ok, je descends alors");
        yield return new WaitForSeconds(1);
        soustitres.SetText("�");
        player.GetComponent<FPC>().haveToDegaine = true;
        yield return null;
    }
    IEnumerator function6()
    {
        Debug.Log("ligne 20");
        soustitres.SetText("Je suis arriv�e dans un couloir je vais o� maintenant?");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 21");
        soustitres.SetText("Tu dois avoir la salle de contr�le devant toi. Tu as besoin de la carte d'acc�s pour ouvrir cette pi�ce. Il doit y avoir mon ancienne carte dans mon bureau. Il y a une carte de secours derri�re le tableau avec les oiseaux. Trouve la et reviens ici. ");
        yield return new WaitForSeconds(1);
        soustitres.SetText("�");
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
        soustitres.SetText("�");
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
