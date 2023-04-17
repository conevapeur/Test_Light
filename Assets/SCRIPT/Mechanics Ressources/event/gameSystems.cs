using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class gameSystems : MonoBehaviour
{
    //GameObject[] triggers = new GameObject[5];

    public AudioClip[] dialogues = new AudioClip[8];

    public GameObject[] locations = new GameObject[8];

    public int arraySize = 8;
    public int cpt;



    [SerializeField] TMP_Text soustitres;
    [SerializeField] GameObject talkie;
    [SerializeField] AudioSource audioSource = null;
    [SerializeField] AudioClip audioClip;
    public GameObject monster;

    private string coroutineName;
    // Start is called before the first frame update
    void Start()
    {
        cpt = 0;
        arraySize = 8;
        coroutineName = "function" + cpt;
        //Debug.Log(coroutineName);

        audioSource = talkie.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(("function1")());
    }

    

    public void testFunction()
    {
        monster.transform.position = locations[cpt].transform.position;
        //Debug.Log("position du monstre : " + (cpt+1));
        //Debug.Log("dialogue n� " + (cpt +1) +" : "+ dialogues[cpt]);
        getExchange(cpt);

        Debug.Log("echange num�ro : " + (cpt + 1));

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
        soustitres.SetText("Papa je suis tomb�e dans un trou, je peux pas sortir.");
        audioSource.clip = audioClip; 
        audioSource.Play();

        yield return new WaitForSeconds(2);
        Debug.Log("ligne 2");
        soustitres.SetText("Dans un trou? Qu'est ce que tu vois?");
        audioSource.Play();

        yield return new WaitForSeconds(3);
        Debug.Log("ligne 3");
        soustitres.SetText("Y a une grande porte, toute veille avec des cailloux."); 
        audioSource.Play();

        yield return new WaitForSeconds(4);
        Debug.Log("ligne 4");
        soustitres.SetText("Est ce qu'il y a marqu� quelque chose sur la porte?");
        audioSource.Play();

        yield return new WaitForSeconds(4);
        Debug.Log("ligne 5");
        soustitres.SetText("Oui, y a marqu� B-SKY-19 dessus.");
        audioSource.Play();

        yield return new WaitForSeconds(4);
        Debug.Log("ligne 6");
        soustitres.SetText("Ok, je connais cet endroit. Je travaillais l� avant. Ne t'inqui�tes pas. Si la porte est ferm�e devant toi, tu devrais apercevoir un conduit d�a�ration sur la droite. Passe-y.");
        audioSource.Play();

        yield return new WaitForSeconds(7);
        soustitres.SetText("�");
        yield return null;
    }

    IEnumerator function1()
    {
        Debug.Log("ligne 7");
        soustitres.SetText("J�y suis papa, je fais quoi maintenant?");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 8");
        soustitres.SetText("(voix gr�sillante) passe par la porte et suit le couloir.");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 9");
        soustitres.SetText("Je t'entends pas papa.");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 10");
        soustitres.SetText("Passe par la porte de la r�serve, une fois sortie, tu vas te retrouver � l�accueil. Continue le couloir et tu devrais arriver au niveau inf�rieur");
        yield return new WaitForSeconds(1);
        soustitres.SetText("�");
        yield return null;
    }

    IEnumerator function2()
    {
        Debug.Log("ligne 11");
        soustitres.SetText("Papa, la porte est ferm�e, je fais quoi?");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 12");
        soustitres.SetText("l'�lectricit�...  il faut que tu remettes l��lectricit�. Le g�n�rateur de secours devrait �tre dans une salle � gauche.Tu n'auras qu'� abaisser le levier et �a devrait marcher.");
        yield return new WaitForSeconds(1);
        soustitres.SetText("�");
        yield return null;
    }
    IEnumerator function3()
    {
        Debug.Log("ligne 13");
        soustitres.SetText("Y a quelque chose qui bloque derri�re la porte. J'peux pas l'ouvrir.");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 14");
        soustitres.SetText("Trouve un moyen de passer au-dessus. Prends une chaise ou un objet pour escalader.");
        yield return new WaitForSeconds(1);
        soustitres.SetText("�");
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
        yield return null;
    }

    IEnumerator function5()
    {
        Debug.Log("ligne 17");
        soustitres.SetText("Papa, t�es s�r que c�est le bon chemin, les escaliers sont cass�s, on ne pourra pas revenir par l�.");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 18");
        soustitres.SetText("Oui, il y a une autre sortie de l'autre c�t�, on sortira par l�.");
        yield return new WaitForSeconds(1);
        Debug.Log("ligne 19");
        soustitres.SetText("Ok, je descends alors");
        yield return new WaitForSeconds(1);
        soustitres.SetText("�");
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
        yield return null;
    }
    

}
