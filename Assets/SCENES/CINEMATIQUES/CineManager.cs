using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private AudioSource audioPrincipale;
    [SerializeField] private UnityEvent TextFR;
    [SerializeField] private UnityEvent TextENG;

    private void Awake()
    {
        animator.SetTrigger("triggercine");

        controls = new UI();
        controls.Menu.back.performed += ctx => Skip();

        if (UIStart.ENG)
        {
            TextENG.Invoke();
        }
        else
        {
            TextFR.Invoke();

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

}
