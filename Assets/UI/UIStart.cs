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
    [SerializeField] private GameObject sliderButton;
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





    [SerializeField] private GameObject checkEnglish;
    [SerializeField] private GameObject checkFrench;
    [SerializeField] private GameObject checkSubtitles;
    [SerializeField] private GameObject boxEnglish;
    [SerializeField] private GameObject boxFrench;
    [SerializeField] private GameObject boxSubtitles;






    private UI uicontrols;



    private void Awake()
    {
        uicontrols = new UI();
        uicontrols.Menu.back.performed += ctx => Back();

        _eventSystem.SetSelectedGameObject(resumeButton);
        options.SetActive(false);
        start.SetActive(true);
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

    public void Options()
    {
        start.SetActive(false);
        options.SetActive(true);
        volume.SetActive(false);
        controls.SetActive(false);
        language.SetActive(false);

        _eventSystem.SetSelectedGameObject(volumeButton);

    }

    public void Language()
    {
        _eventSystem.SetSelectedGameObject(englishButton); 
    }

    public void English()
    {
        
        
        englishButton.GetComponent<Button>().interactable = false;
        frenchButton.GetComponent<Button>().interactable = true;
        checkEnglish.SetActive(true);
        checkFrench.SetActive(false);
        

    }
    public void French()
    {
        
        
        frenchButton.GetComponent<Button>().interactable = false;
        englishButton.GetComponent<Button>().interactable = true;
        checkFrench.SetActive(true);
        checkEnglish.SetActive(false);


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
    }
}
