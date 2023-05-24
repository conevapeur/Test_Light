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

    public AudioClip[] dialogues = new AudioClip[14];

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
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().curFreq = talkie.GetComponent<talkie>().state;
            player.GetComponent<FPC>().lockAbilities("listening");
            player.GetComponent<FPC>().animator.SetTrigger("triggerTalk");

            talkie.GetComponent<talkie>().myAudioSource.clip = dialogues[0];
            talkie.GetComponent<talkie>().myAudioSource.Play();

            /*
            AudioClip.play
            soustitre.setText(tableau[ligne][langue]);

            Wait(AudioClip.isplaying == false)
            */

            Debug.Log("ligne 1");
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
            soustitres.SetText("�");
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

    }

    IEnumerator function1()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().curFreq = 3;
            player.GetComponent<FPC>().lockAbilities("listening");

            Debug.Log("ligne 7");
            soustitres.SetText("I'm here Dad, what do I do now?");
            yield return new WaitForSeconds(1);

            /*
            Debug.Log("ligne 8");
            soustitres.SetText("(voix gr�sillante) passe par la porte et suit le couloir.");
            yield return new WaitForSeconds(1);
            */

            Debug.Log("ligne 9");
            soustitres.SetText("Dad, I can't hear you.");
            yield return new WaitForSeconds(1);


            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(2);
            }

            player.GetComponent<FPC>().recover();

            Debug.Log("ligne 10");
            soustitres.SetText("Go through the cabinet door, it will lead you to the reception. Go to the end of the corridor, the door to the lower level should be there.");
            yield return new WaitForSeconds(1);


            soustitres.SetText("�");
            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
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

    }

    IEnumerator function2()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().curFreq = 1;
            player.GetComponent<FPC>().lockAbilities("listening");
            Debug.Log("ligne 11");
            soustitres.SetText("Dad, the door is shut, where do I go now??");
            yield return new WaitForSeconds(1);

            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(2);
            }
            player.GetComponent<FPC>().recover();
            Debug.Log("ligne 12");
            soustitres.SetText("Hmmm Electricity... you need to put the power back on. Emergency generator should be in a room on your left. You'd just have to lower the lever and it should do the trick..");
            yield return new WaitForSeconds(1);
            soustitres.SetText("�");
            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
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

    }
    IEnumerator function3()
    {
        if (UIStart.ENG)
        {
            talkie.GetComponent<talkie>().curFreq = 4;
            player.GetComponent<FPC>().lockAbilities("listening");
            Debug.Log("ligne 13");
            soustitres.SetText("There's something behind the door. I can't open it.");
            yield return new WaitForSeconds(1);

            while (talkie.GetComponent<talkie>().curFreq != talkie.GetComponent<talkie>().state)
            {
                Debug.Log("audio parasite");
                yield return new WaitForSeconds(2);
            }
            player.GetComponent<FPC>().recover();
            Debug.Log("ligne 14");
            soustitres.SetText("You have to find a way to go through it. Help yourself with a chair or something to climb.");
            yield return new WaitForSeconds(1);
            soustitres.SetText("�");
            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
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

    }
    IEnumerator function4()
    {
        if (UIStart.ENG)
        {
            Debug.Log("ligne 15");
            soustitres.SetText("I went through dad.");
            yield return new WaitForSeconds(1);
            Debug.Log("ligne 16");
            soustitres.SetText("Go on, generator should be down the stairs. Pull the lever down to activate it..");
            yield return new WaitForSeconds(1);
            soustitres.SetText("�");
            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
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

    }

    IEnumerator function5()
    {
        if (UIStart.ENG)
        {
            player.GetComponent<FPC>().lockAbilities("listening");

            Debug.Log("ligne 17");
            soustitres.SetText("Dad, You're sure it is the right way? The stairs are broken, we won't be able to come back this way.");
            yield return new WaitForSeconds(1);
            Debug.Log("ligne 18");
            soustitres.SetText("Yes, there is another exit on the other side, we will go out this way.");
            yield return new WaitForSeconds(1);


            player.GetComponent<FPC>().recover();

            Debug.Log("ligne 19");
            soustitres.SetText("OK, I'm coming down then");
            yield return new WaitForSeconds(1);
            soustitres.SetText("�");
            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
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

    }
    IEnumerator function6()
    {
        if (UIStart.ENG)
        {
            Debug.Log("ligne 20");
            soustitres.SetText("I'm in a corridor, which way I go now?");
            yield return new WaitForSeconds(1);
            Debug.Log("ligne 21");
            soustitres.SetText("You need to go in the control room in front of you. You need the spare card to enter this room. My old one is in my office, behind the picture with the birds. Find it and come back here.");
            yield return new WaitForSeconds(1);
            soustitres.SetText("�");
            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
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

    }
    IEnumerator function7()
    {
        if (UIStart.ENG)
        {
            Debug.Log("ligne 22");
            soustitres.SetText(" I'm going in the room Dad.");
            yield return new WaitForSeconds(1);
            Debug.Log("ligne 23");
            soustitres.SetText("You see the red button in the middle? Push it.");
            yield return new WaitForSeconds(1);
            soustitres.SetText("�");
            player.GetComponent<FPC>().haveToDegaine = true;
            yield return null;
        }



        else
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
