using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    
    [Header("Info")] 
    [SerializeField] private GameObject infosMenu;
    [SerializeField] private GameObject readable1;
    [SerializeField] private GameObject readable2;
    [SerializeField] private GameObject readable3;
    [SerializeField] private GameObject readable4;
    [SerializeField] private GameObject readableButton1;
    [SerializeField] private GameObject readableButton2;
    [SerializeField] private GameObject readableButton3;
    [SerializeField] private GameObject readableButton4;

    [Header("option")]
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Slider slider1;
    [SerializeField] private GameObject _slider1;
    [SerializeField] private Slider slider2;
    [SerializeField] private GameObject _slider2;
    [SerializeField] private Slider slider3;
    [SerializeField] private GameObject _slider3;
    [SerializeField] private Slider slider4;
    [SerializeField] private GameObject _slider4;
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text text3;
    [SerializeField] private TMP_Text text4;
    [SerializeField] private GameObject panelVolume;
    [SerializeField] private GameObject frenchButton;
    [SerializeField] private GameObject englishButton;
    [SerializeField] private GameObject languageButton;


    private UI controls;

    [Header("Event")] // selectionner le bouton quand l'ui s'affiche
   
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject optionButton;
    [SerializeField] private GameObject infosButton;
    [SerializeField] private GameObject volumeButton;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private string scene;

    [SerializeField] private GameObject _volume;
    [SerializeField] private GameObject _controls;
    [SerializeField] private GameObject _language;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        infosMenu.SetActive(false);
        optionsMenu.SetActive(false);

        controls = new UI();
        controls.Menu.escape.performed += ctx => Pause();
        controls.Menu.back.performed += ctx => Back();

        readable1.gameObject.SetActive(false);
        readable2.gameObject.SetActive(false);
        readable3.gameObject.SetActive(false);
        readable4.gameObject.SetActive(false);
        _controls.gameObject.SetActive(false);
        _language.gameObject.SetActive(false);
        panelVolume.gameObject.SetActive(false);

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FPC.canLook = true;
        FPC.canMove = true;
        FPC.canSidewalk = true;

    }

    private void Pause()
    {
        if (Time.timeScale != 0f) 
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(resumeButton);
            FPC.canLook = false;
            FPC.canMove = false;
            FPC.canSidewalk = false;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(scene);
    }
    public void Infos()
    {
        infosMenu.SetActive(true);
        pauseMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(readableButton1);
    }

    public void Back()
    {

        if (pauseMenu.activeInHierarchy) 
        {
            Resume();
        }

        else if (_eventSystem.currentSelectedGameObject == _slider1 || _eventSystem.currentSelectedGameObject == _slider2 || _eventSystem.currentSelectedGameObject == _slider3 || _eventSystem.currentSelectedGameObject == _slider4)
        {
            _eventSystem.SetSelectedGameObject(volumeButton);
            panelVolume.gameObject.SetActive(false);
        }
        else if (_eventSystem.currentSelectedGameObject == frenchButton || _eventSystem.currentSelectedGameObject == englishButton)
        {
            _eventSystem.SetSelectedGameObject(languageButton);
        }
        else if (optionsMenu.activeInHierarchy)
        {
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(optionButton);
        }

        else if (readable1.activeInHierarchy)
        {
            readable1.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton1);
        }
        else if (readable2.activeInHierarchy)
        {
            readable2.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton2);
        }
        else if (readable3.activeInHierarchy)
        {
            readable3.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton3);
        }
        else if (readable4.activeInHierarchy)
        {
            readable4.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton4);
        }
        else if (infosMenu.activeInHierarchy)
        {
            infosMenu.SetActive(false);
            pauseMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(infosButton);
        }


       
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(volumeButton);

    }

    public void Volume()
    {
        _volume.SetActive(true);
        _controls.SetActive(false);
        _language.SetActive(false);
    }
    public void Controls()
    {
        _volume.SetActive(false);
        _controls.SetActive(true);
        _language.SetActive(false);
    }
    public void Language()
    {
        _volume.SetActive(false);
        _controls.SetActive(false);
        _language.SetActive(true);
    }

    public void readable()  // ici c'est pas terrible mais ca marche
    {
        if (_eventSystem.currentSelectedGameObject == readableButton1)
        {
            if (interactReadable.readable1 == true)
            {
                readable1.gameObject.SetActive(true);
                _eventSystem.SetSelectedGameObject(null);
            }
            readable2.gameObject.SetActive(false);
            readable3.gameObject.SetActive(false);
            readable4.gameObject.SetActive(false);
        }
        if (_eventSystem.currentSelectedGameObject == readableButton2)
        {
            if (interactReadable.readable2 == true)
            {
                readable2.gameObject.SetActive(true);
                _eventSystem.SetSelectedGameObject(null);
            }
            readable1.gameObject.SetActive(false);
            readable3.gameObject.SetActive(false);
            readable4.gameObject.SetActive(false);
        }
        if (_eventSystem.currentSelectedGameObject == readableButton3)
        {
            if (interactReadable.readable3 == true)
            {
                readable3.gameObject.SetActive(true);
                _eventSystem.SetSelectedGameObject(null);
            }
            readable1.gameObject.SetActive(false);
            readable2.gameObject.SetActive(false);
            readable4.gameObject.SetActive(false);
        }
        if (_eventSystem.currentSelectedGameObject == readableButton4)
        {
            if (interactReadable.readable4 == true)
            {
                readable4.gameObject.SetActive(true);
                _eventSystem.SetSelectedGameObject(null);
            }
            readable1.gameObject.SetActive(false);
            readable2.gameObject.SetActive(false);
            readable3.gameObject.SetActive(false);
        }
    }

    public void French()
    {
        //changer langue
    }

    public void English()
    {
        //changer langue

    }



    private void Update()
    {
        if (interactReadable.readable1 == true)
        {
            readableButton1.gameObject.SetActive(true);
        }
        if (interactReadable.readable2 == true)
        {
            readableButton2.gameObject.SetActive(true);
        }
        if (interactReadable.readable3 == true)
        {
            readableButton3.gameObject.SetActive(true);
        }
        if (interactReadable.readable4 == true)
        {
            readableButton4.gameObject.SetActive(true);
        }

        if (_eventSystem.currentSelectedGameObject == _slider1 || _eventSystem.currentSelectedGameObject == _slider2 || _eventSystem.currentSelectedGameObject == _slider3 || _eventSystem.currentSelectedGameObject == _slider4)
        {
            panelVolume.gameObject.SetActive(true);
        }
        if (_eventSystem.currentSelectedGameObject == frenchButton || _eventSystem.currentSelectedGameObject == englishButton)
        {
            panelVolume.gameObject.SetActive(true);
        }
        
        text1.text = ("volume principal ") + (slider1.value ).ToString();
        text2.text = ("volume musique ") + (slider2.value ).ToString();
        text3.text = ("volume effet sonore ") + (slider3.value ).ToString();
        text4.text = ("volume dialogue ") + (slider4.value ).ToString();
        
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
