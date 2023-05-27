using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class endManager : MonoBehaviour
{

    private UI controls;
    int score = 0;


    [SerializeField] private Animator animator;

    [SerializeField] private Animator animatorSkip;

    private bool musicFadeOutEnabled = false;

    [SerializeField] private AudioSource audioPrincipale;
    [SerializeField] private AudioSource dialfr;
    [SerializeField] private AudioSource dialeng;
    [SerializeField] private AudioSource cri;

    [SerializeField] private GameObject engcred;


    private void Awake()
    {
        controls = new UI();
        controls.Menu.back.performed += ctx => Skip();

        if (UIStart.ENG)
        {
            engcred.SetActive(true);
        }
        else
        {
            engcred.SetActive(false);
        }
    }

    public void ChangeScene()
    {

        SceneManager.LoadScene("START SCENE");
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
        if (musicFadeOutEnabled)
        {

            float newVolume = audioPrincipale.volume - (0.3f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
            if (newVolume < 0f)
            {
                newVolume = 0f;
            }
            audioPrincipale.volume = newVolume;

        }
    }

    private void OnEnable()
    {
        controls.Menu.Enable();
    }
    private void OnDisable()
    {
        controls.Menu.Disable();
    }

    public void Sound()
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

    public void Music()
    {
        audioPrincipale.Play();
    }

    public void Cri()
    {
        cri.Play();
    }
}

