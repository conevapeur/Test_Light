using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CineManager : MonoBehaviour
{

    private UI controls;
    int score = 0;

    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorSkip;

    private bool musicFadeOutEnabled = false;
    //[SerializeField] private AudioSource audioPrincipale;

    [SerializeField] private AudioSource yawn;
    [SerializeField] private AudioSource tv;
    [SerializeField] private AudioSource huh;
    [SerializeField] private AudioSource door;
    [SerializeField] private AudioSource talkie;
    [SerializeField] private AudioSource cereal;
    [SerializeField] private AudioSource page;

    [SerializeField] private AudioSource forest;

    [SerializeField] private AudioSource dialfr;
    [SerializeField] private AudioSource dialeng;

    [SerializeField] private AudioSource newsfr;
    [SerializeField] private AudioSource newseng;


    [SerializeField] private Texture notefr;
    [SerializeField] private Texture noteeng;
    [SerializeField] private GameObject note;
    

    private void Awake()
    {
        animator.SetTrigger("triggercine");

        controls = new UI();
        controls.Menu.back.performed += ctx => Skip();


        if (UIStart.ENG)
        {

            var image = note.GetComponent<RawImage>().texture;
            image = noteeng;
            note.GetComponent<RawImage>().texture = image;
            var alpha = note.GetComponent<RawImage>().color;
            alpha.a = 0;
            note.GetComponent<RawImage>().color = alpha;
        }
        else
        {
            var image = note.GetComponent<RawImage>().texture;
            image = notefr;
            note.GetComponent<RawImage>().texture = image;
            var alpha = note.GetComponent<RawImage>().color;
            alpha.a = 0;
            note.GetComponent<RawImage>().color = alpha;
        }
        

    }

    public void ChangeScene()
    {

        SceneManager.LoadScene("END");
    }

    public void EndAnim()
    {
        StartCoroutine(NextScene());
    }


    void Skip()
    {
        Debug.Log("pouet");
        if (score == 0)
        {
            score += 1;
            animatorSkip.SetTrigger("trigger");
        }
        else
        {
            //skipButton.GetComponent<Button>().enabled = false;
            ChangeScene();
        }
    }

    IEnumerator NextScene()
    {
        musicFadeOutEnabled = true;

        yield return new WaitForSeconds(3);
        ChangeScene();

    }

    private void Update()
    {
        /*
        if (musicFadeOutEnabled)
        {

            float newVolume = audioPrincipale.volume - (0.3f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
            if (newVolume < 0f)
            {
                newVolume = 0f;
            }
            audioPrincipale.volume = newVolume;

        }
        */
    }

    private void OnEnable()
    {
        controls.Menu.Enable();
    }
    private void OnDisable()
    {
        controls.Menu.Disable();
    } 




    


    // play sound for animation

    public void Sound1()
    {
        yawn.Play();
    }

    public void Sound2()
    {
        tv.Play();
    }

    public void Sound3()
    {
        huh.Play();
    }

    public void Sound4()
    {
        cereal.Play();
    }

    public void Sound5()
    {
        talkie.Play();
    }

    public void Sound6()
    {
        door.Play();
    }

    public void Sound7()
    {
        page.Play();
    }

    public void Sound8()
    {
        forest.Play();
    }

    public void Sound9()
    {
        if (UIStart.ENG)
        {
            newseng.Play();
        }
        else
        {
            newsfr.Play();
        }
    }

    public void Sound10()
    {
        if (UIStart.ENG)
        {
            dialeng.Play();
        }
        else
        {
            dialfr.Play();
        }
    }

}
