using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.AI;
using System.Drawing;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    /////////////////////// Game
    public int progression;
    //public Vector3 lastCheckpoint;

    public string coroutineName;


    public GameObject player;
    

    
    public GameObject talkie;

    public int frequenceP = 0;
    public int frequenceM;

    public AudioClip[] dialoguesENG = new AudioClip[14];
    public AudioClip[] dialoguesFR = new AudioClip[14];

    ////////////////////////// Monster
    public GameObject monster;

    public GameObject[] locations = new GameObject[8];

    public float distancePM;
    public float navDistancePM;


    public TMP_Text soustitres;
    [SerializeField] private GameObject gotext; // pour desactiver les sous titres si decocher dans ui
    [SerializeField] private GameObject fondNoir;

    public GameObject bumperTuto;

    /*
    [SerializeField] GameObject firstRoom;
    [SerializeField] GameObject secondRoom;
    [SerializeField] GameObject couloirRoom;
    */
    public GameObject Caller;

    public Animator animatorUI;



    public bool dying = false;
    public Vector3 lastCheckpoint;
    public GameObject[] checkpoints = new GameObject[8];


    public AudioSource myAudioSource;
    public AudioClip criMonstre;
    public AudioClip deathSound;
    public AudioClip breakingGlass;


    //public GameObject[] _decals = new GameObject[0]; 

    public GameObject _decals;


    private void Awake()
    {
        fondNoir.SetActive(false);
        myAudioSource = GetComponent<AudioSource>();

        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente

        instance = this;

        DontDestroyOnLoad(this.gameObject);



        if (UIStart.SUB) // sous titres
        {
            gotext.SetActive(true);
        }else
        {
            gotext.SetActive(false);
        }

        bumperTuto.SetActive(false);
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
        /*if (progression >= locations.Length)
        {
            progression = 0;
        }*/
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
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().curFreq = talkie.GetComponent<talkie>().state;
            player.GetComponent<FPC>().lockAbilities("listening");
            player.GetComponent<FPC>().animator.SetTrigger("triggerTalk");

            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[0];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            /*
            AudioClip.play
            soustitre.setText(tableau[ligne][langue]);

            Wait(AudioClip.isplaying == false)
            */

            Debug.Log("ligne 1");
            fondNoir.SetActive(true);

            soustitres.SetText("Dad, I fell in a hole, I can't get out.");
            //audioSource.clip = audioClip;
            //audioSource.Play();

            yield return new WaitForSeconds(2);
            Debug.Log("ligne 2");
            soustitres.SetText("In a hole? What do you see?");
            //audioSource.Play();

            yield return new WaitForSeconds(3);
            Debug.Log("ligne 3");
            soustitres.SetText("There is a big door, all old and rocks.");
            //audioSource.Play();

            yield return new WaitForSeconds(4);
            Debug.Log("ligne 4");
            soustitres.SetText("Do you see something written on the door?");
            //audioSource.Play();

            yield return new WaitForSeconds(4);
            Debug.Log("ligne 5");
            soustitres.SetText("Yes, something like B-SKY-19 is written.");
            //audioSource.Play();

            yield return new WaitForSeconds(4);

            player.GetComponent<FPC>().recover();


            Debug.Log("ligne 6");
            soustitres.SetText("Ok, I know the place. I used to work there before. Don'worry. If the door in front of you is closed, you should be able to see a vent on your right. Go through it.");
            //audioSource.Play();

            yield return new WaitForSeconds(7);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            //player.GetComponent<FPC>().haveToDegaine = true;
            player.GetComponent<FPC>().animator.SetTrigger("triggerEndTalk");
            yield return null;
        }



        else
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
            fondNoir.SetActive(true);

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
            fondNoir.SetActive(false);

            soustitres.SetText(" ");
            //player.GetComponent<FPC>().haveToDegaine = true;
            player.GetComponent<FPC>().animator.SetTrigger("triggerEndTalk");
            yield return null;
        }

    }

    IEnumerator function1()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[1];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            talkie.GetComponent<talkie>().curFreq = 3;
            player.GetComponent<FPC>().lockAbilities("listening");

            Debug.Log("ligne 7");
            fondNoir.SetActive(true);

            soustitres.SetText("I'm here Dad, what do I do now?");
            yield return new WaitForSeconds(1);

            /*
            Debug.Log("ligne 8");
            soustitres.SetText("(voix grésillante) passe par la porte et suit le couloir.");
            yield return new WaitForSeconds(1);
            */

            Debug.Log("ligne 9");
            soustitres.SetText("Dad, I can't hear you.");

            bumperTuto.SetActive(true);

            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[3];
            talkie.GetComponent<talkie>().myAudioSource.Play();
            yield return new WaitForSeconds(2);


            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(.5f);
            }

            player.GetComponent<FPC>().recover();
            bumperTuto.SetActive(false);

            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[4];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            Debug.Log("ligne 10");
            soustitres.SetText("Go through the cabinet door, it will lead you to the reception. Go to the end of the corridor, the door to the lower level should be there.");
            yield return new WaitForSeconds(6);


            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
        {
            talkie.GetComponent<talkie>().curFreq = 3;
            player.GetComponent<FPC>().lockAbilities("listening");

            Debug.Log("ligne 7");
            fondNoir.SetActive(true);

            soustitres.SetText("J’y suis papa, je fais quoi maintenant?");
            yield return new WaitForSeconds(3);

            /*
            Debug.Log("ligne 8");
            soustitres.SetText("(voix grésillante) passe par la porte et suit le couloir.");
            yield return new WaitForSeconds(1);
            */

            Debug.Log("ligne 9");
            soustitres.SetText("Je t'entends pas papa.");

            bumperTuto.SetActive(true);

            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[3];
            talkie.GetComponent<talkie>().myAudioSource.Play();
            yield return new WaitForSeconds(2);


            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(.5f);
            }

            player.GetComponent<FPC>().recover();

            bumperTuto.SetActive(false);
            Debug.Log("ligne 10");
            soustitres.SetText("Passe par la porte de la réserve, une fois sortie, tu vas te retrouver à l’accueil. Continue le couloir et tu devrais arriver au niveau inférieur");
            yield return new WaitForSeconds(5);


            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }

    }

    IEnumerator function2()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[5];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            talkie.GetComponent<talkie>().curFreq = 1;
            player.GetComponent<FPC>().lockAbilities("listening");
            Debug.Log("ligne 11");
            fondNoir.SetActive(true);

            soustitres.SetText("Dad, the door is shut, where do I go now??");
            yield return new WaitForSeconds(3);

            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(1);
            }
            player.GetComponent<FPC>().recover();

            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[6];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            Debug.Log("ligne 12");
            soustitres.SetText("Hmmm Electricity... you need to put the power back on. Emergency generator should be in a room on your left. You'd just have to lower the lever and it should do the trick..");
            yield return new WaitForSeconds(5);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
        {
            talkie.GetComponent<talkie>().curFreq = 1;
            player.GetComponent<FPC>().lockAbilities("listening");
            Debug.Log("ligne 11");
            fondNoir.SetActive(true);

            soustitres.SetText("Papa, la porte est fermée, je fais quoi?");
            yield return new WaitForSeconds(3);

            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(1);
            }
            player.GetComponent<FPC>().recover();
            Debug.Log("ligne 12");
            soustitres.SetText("l'électricité...  il faut que tu remettes l’électricité. Le générateur de secours devrait être dans une salle à gauche.Tu n'auras qu'à abaisser le levier et ça devrait marcher.");
            yield return new WaitForSeconds(5);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }

    }
    IEnumerator function3()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[7];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            talkie.GetComponent<talkie>().curFreq = 4;
            player.GetComponent<FPC>().lockAbilities("listening");
            Debug.Log("ligne 13");
            fondNoir.SetActive(true);

            soustitres.SetText("There's something behind the door. I can't open it.");
            yield return new WaitForSeconds(4);

            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(1);
            }
            player.GetComponent<FPC>().recover();

            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[8];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            Debug.Log("ligne 14");
            soustitres.SetText("You have to find a way to go through it. Help yourself with a chair or something to climb.");
            yield return new WaitForSeconds(4);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
        {
            talkie.GetComponent<talkie>().curFreq = 4;
            player.GetComponent<FPC>().lockAbilities("listening");
            Debug.Log("ligne 13");
            fondNoir.SetActive(true);

            soustitres.SetText("Y a quelque chose qui bloque derrière la porte. J'peux pas l'ouvrir.");
            yield return new WaitForSeconds(3);

            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(1);
            }
            player.GetComponent<FPC>().recover();
            Debug.Log("ligne 14");
            soustitres.SetText("Trouve un moyen de passer au-dessus. Prends une chaise ou un objet pour escalader.");
            yield return new WaitForSeconds(4);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }

    }
    IEnumerator function4()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[9];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            Debug.Log("ligne 15");
            fondNoir.SetActive(true);

            soustitres.SetText("I went through dad.");
            yield return new WaitForSeconds(2);
            Debug.Log("ligne 16");
            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[10];
            talkie.GetComponent<talkie>().myAudioSource.Play();
            soustitres.SetText("Go on, generator should be down the stairs. Pull the lever down to activate it..");
            yield return new WaitForSeconds(4);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
        {
            Debug.Log("ligne 15");
            fondNoir.SetActive(true);

            soustitres.SetText("Je suis passée papa");
            yield return new WaitForSeconds(1);
            Debug.Log("ligne 16");
            soustitres.SetText("Continue, le générateur est en bas de l’escalier. Pour l’actionner, tire le levier vers le bas.");
            yield return new WaitForSeconds(4);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }

    }

    IEnumerator function5()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[11];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            player.GetComponent<FPC>().lockAbilities("listening");

            Debug.Log("ligne 17");
            fondNoir.SetActive(true);

            soustitres.SetText("Dad, You're sure it is the right way? The stairs are broken, we won't be able to come back this way.");
            yield return new WaitForSeconds(5);
            Debug.Log("ligne 18");
            soustitres.SetText("Yes, there is another exit on the other side, we will go out this way.");
            yield return new WaitForSeconds(3);


            player.GetComponent<FPC>().recover();

            Debug.Log("ligne 19");
            soustitres.SetText("OK, I'm coming down then");
            yield return new WaitForSeconds(2);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
        {
            player.GetComponent<FPC>().lockAbilities("listening");

            Debug.Log("ligne 17");
            fondNoir.SetActive(true);

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
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }

    }
    IEnumerator function6()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[12];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            Debug.Log("ligne 20");
            fondNoir.SetActive(true);

            soustitres.SetText("I'm in a corridor, which way I go now?");
            yield return new WaitForSeconds(3);
            Debug.Log("ligne 21");
            soustitres.SetText("You need to go in the control room in front of you. You need the spare card to enter this room. My old one is in my office, behind the picture with the birds. Find it and come back here.");
            yield return new WaitForSeconds(6);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
        {
            Debug.Log("ligne 20");
            fondNoir.SetActive(true);

            soustitres.SetText("Je suis arrivée dans un couloir je vais où maintenant?");
            yield return new WaitForSeconds(4);
            Debug.Log("ligne 21");
            soustitres.SetText("Tu dois avoir la salle de contrôle devant toi. Tu as besoin de la carte d'accès pour ouvrir cette pièce. Il doit y avoir mon ancienne carte dans mon bureau. Il y a une carte de secours derrière le tableau avec les oiseaux. Trouve la et reviens ici. ");
            yield return new WaitForSeconds(6);
            soustitres.SetText(" ");
            fondNoir.SetActive(false) ;
            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }

    }
    IEnumerator function7()
    {
        talkie.GetComponent<talkie>().myAudioSource.clip = dialoguesENG[13];
        talkie.GetComponent<talkie>().myAudioSource.Play();

        if (UIStart.ENG)
        {
            Debug.Log("ligne 22");
            fondNoir.SetActive(true);

            soustitres.SetText(" I'm going in the room Dad.");
            yield return new WaitForSeconds(3);
            Debug.Log("ligne 23");
            soustitres.SetText("You see the red button in the middle? Push it.");
            yield return new WaitForSeconds(7);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
        {
            Debug.Log("ligne 22");
            fondNoir.SetActive(true);

            soustitres.SetText("Je rentre dans la salle papa.");
            yield return new WaitForSeconds(1);
            Debug.Log("ligne 23");
            soustitres.SetText("Tu vois le bouton rouge? appuie dessus. ");
            yield return new WaitForSeconds(1);
            soustitres.SetText(" ");
            fondNoir.SetActive(false);

            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }

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
        Vector3 start = Vector3.zero;
        
        Vector3 point = Vector3.zero;

        //GameObject[] _decals;

        if (Caller.TryGetComponent<debrisVerre>(out debrisVerre script))
        {
            start = script.start.transform.position;
            point = script.point.transform.position;
            if(script.decals != null)
            {
                _decals = script.decals;
            }
            
            //Debug.Log(start);
            //Debug.Log(point);
        }



        monster.GetComponent<NavMeshAgent>().enabled = false;
        //monster.transform.position = firstRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        monster.transform.position = start;
        monster.GetComponent<NavMeshAgent>().enabled = true;

        //myAudioSource.clip = breakingGlass;
        //myAudioSource.Play();

        yield return new WaitForSeconds(.5f);

        myAudioSource.clip = criMonstre;
        myAudioSource.Play();

        //monster.GetComponent<NavMeshAgent>().destination = firstRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        monster.GetComponent<NavMeshAgent>().destination = start;
        yield return new WaitForSeconds(5);


        //monster.GetComponent<NavMeshAgent>().destination = firstRoom.GetComponent<firstRoomTrigger>().point.transform.position;
        //monster.GetComponent<NavMeshAgent>().destination = player.transform.position;
        monster.GetComponent<NavMeshAgent>().destination = point;
        yield return new WaitForSeconds(5);

        /*
        if(_decals.Length >=0)
        {
            for (int i = 0; i<_decals.Length ; i++)
            {
                _decals[i].SetActive(true);
            }
        }
        */
        if (_decals != null)
            _decals.SetActive(true);

        //monster.GetComponent<NavMeshAgent>().destination = firstRoom.GetComponent<firstRoomTrigger>().start.transform.position;
        monster.GetComponent<NavMeshAgent>().destination = start;
        yield return new WaitForSeconds(5);


        monster.GetComponent<NavMeshAgent>().enabled = false;
        monster.transform.position = locations[0].transform.position;
        monster.GetComponent<NavMeshAgent>().enabled = true;

        yield return null;
    }

    /*
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
    */
    #endregion

    public GameObject[] triggers = new GameObject[10];
    public void Die()
    {
        if(dying == false)
        {
            StartCoroutine(CoroutineDie());
            dying = true;
        }
        
    }

    IEnumerator CoroutineDie ()
    {
        player.GetComponent<FPC>().lockAbilities("scared");
        player.GetComponent<FPC>().animator.SetTrigger("die");

        yield return new WaitForSeconds(2);

        animatorUI.SetTrigger("triggerFade");

        yield return new WaitForSeconds(2);

        if(lastCheckpoint != Vector3.zero)
        {
            player.transform.position = lastCheckpoint;
        }
        
        
        animatorUI.SetTrigger("triggerUnfade");

        
        yield return new WaitForSeconds(2.5f);


        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].transform.position = triggers[i].GetComponent<debrisVerre>().origin;
        }


        //for (int i = 0; i < checkpoints.length; i++)
        //{
        //    checkpoints[i].transform.position = triggers[i].getcomponent<checkpoint>().origin;
        //}

        player.GetComponent<FPC>().recover();
        

        dying = false;

        yield return null;
    }

    


}
