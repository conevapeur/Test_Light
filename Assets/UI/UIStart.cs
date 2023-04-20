using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStart : MonoBehaviour
{
    [Header("Event & Buttons")]
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject volumeButton;
    [SerializeField] private GameObject controlsButton;
    [SerializeField] private GameObject languageButton;
    [SerializeField] private GameObject englishButton;
    [SerializeField] private GameObject frenchButton;
    [SerializeField] private GameObject subtitlesButton;


    [Header("Start")]
    [SerializeField] private GameObject start;


    [Header ("Settings")]
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject volume;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject language;




    [Header("CheckBox")]
    [SerializeField] private GameObject checkEnglish;
    [SerializeField] private GameObject checkFrench;
    [SerializeField] private GameObject checkSubtitles;
    [SerializeField] private GameObject boxEnglish;
    [SerializeField] private GameObject boxFrench;
    [SerializeField] private GameObject boxSubtitles;


    [Header("SoundMark")]
    [SerializeField] private GameObject slider1;
    [SerializeField] private Slider value1;
    [SerializeField] private GameObject soundMark1;
    [SerializeField] private GameObject soundMark2;
    [SerializeField] private GameObject soundMark3;
    [SerializeField] private GameObject soundMark4;
    [SerializeField] private GameObject soundMark5;


    RawImage soundMark1rend;


    private UI uicontrols;



    private void Awake()
    {
        uicontrols = new UI();
        uicontrols.Menu.back.performed += ctx => Back();

        _eventSystem.SetSelectedGameObject(resumeButton);
        options.SetActive(false);
        start.SetActive(true);

        soundMark1rend = soundMark1.GetComponent<RawImage>();
    }

    void Back()
    {
        if(options.activeInHierarchy)
        {
            options.SetActive(false);
            start.SetActive(true);

        }
    }

    public void Play()
    {
        StartCoroutine(ButtonCoroutine()); 
    }
    public void Volume()
    {
        _eventSystem.SetSelectedGameObject(slider1);
    }

    public void Options()
    {
        start.SetActive(false);
        options.SetActive(true);
        volume.SetActive(false);
        controls.SetActive(false);
        language.SetActive(false);

        checkFrench.SetActive(false);
        checkSubtitles.SetActive(false);

        _eventSystem.SetSelectedGameObject(volumeButton);

    }

    public void Language()
    {
        _eventSystem.SetSelectedGameObject(englishButton); 
    }

    public void English()
    {
        
        if (checkEnglish.activeInHierarchy == false)
        {
            checkEnglish.SetActive(true);
            checkFrench.SetActive(false);
        }
    }
    public void French()
    {
        if (checkFrench.activeInHierarchy == false)
        {
            checkFrench.SetActive(true);
            checkEnglish.SetActive(false);
        }
        
    }
    public void Subtitles()
    {

        if (checkSubtitles.activeInHierarchy)
        {
            checkSubtitles.SetActive(false);

        }
        else
        {
            checkSubtitles.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator ButtonCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("TEST LD");
    }

    private void Update()
    {
        if (_eventSystem.currentSelectedGameObject == volumeButton && !volume.activeInHierarchy)
        {
            volume.SetActive(true);
            controls.SetActive(false);
            language.SetActive(false);
        }

        if (_eventSystem.currentSelectedGameObject == controlsButton && !controls.activeInHierarchy)
        {
            volume.SetActive(false);
            controls.SetActive(true);
            language.SetActive(false);
        }

        if (_eventSystem.currentSelectedGameObject == languageButton && !language.activeInHierarchy)
        {
            volume.SetActive(false);
            controls.SetActive(false);
            language.SetActive(true);
        }

        //

        if (value1.value < 20)
        {
            var tempColor = soundMark1rend.color;
            tempColor.a = value1.value/20;
            soundMark1rend.color = tempColor;
            soundMark1.SetActive(true);

            soundMark2.SetActive(false);
            soundMark3.SetActive(false);
            soundMark4.SetActive(false);
            soundMark5.SetActive(false);
        }
        else if (value1.value < 40)
        {
            soundMark1.SetActive(true);
            soundMark2.SetActive(true);
            soundMark3.SetActive(false);
            soundMark4.SetActive(false);
            soundMark5.SetActive(false);

        }
        else if (value1.value < 60)
        {
            soundMark1.SetActive(true);
            soundMark2.SetActive(true);
            soundMark3.SetActive(true);
            soundMark4.SetActive(false);
            soundMark5.SetActive(false);

        }
        else if (value1.value < 80)
        {
            soundMark1.SetActive(true);
            soundMark2.SetActive(true);
            soundMark3.SetActive(true);
            soundMark4.SetActive(true);
            soundMark5.SetActive(false);

        }
        else if (value1.value < 100)
        {
            soundMark1.SetActive(true);
            soundMark2.SetActive(true);
            soundMark3.SetActive(true);
            soundMark4.SetActive(true);
            soundMark5.SetActive(true);

        }



    }
}
