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
    [Header("Pause")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject infosMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private string scene;

    [Space(10)]

    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject optionButton;
    [SerializeField] private GameObject infosButton;
    [SerializeField] private GameObject quitButton;

    [Space(10)]
    [Header("Quit")]
    [SerializeField] private GameObject quitPanel;
    [SerializeField] private GameObject noButton;


    [Space (10)]
    [Header("Readables")] 
    [SerializeField] private GameObject readable1;
    [SerializeField] private GameObject readable2;
    [SerializeField] private GameObject readable3;
    [SerializeField] private GameObject readable4;
    [SerializeField] private GameObject readable5;

    [Space(10)]

    [SerializeField] private GameObject readableButton1;
    [SerializeField] private GameObject readableButton2;
    [SerializeField] private GameObject readableButton3;
    [SerializeField] private GameObject readableButton4;
    [SerializeField] private GameObject readableButton5;

    [Space(10)]
    [Header("Option")]
    [SerializeField] private GameObject languageButton;
    [SerializeField] private GameObject volumeButton;
    [SerializeField] private GameObject panelOption;


    [Header("Volume")]
    [SerializeField] private GameObject _volume;

    [Space(10)]

    [SerializeField] private Slider slider1;
    [SerializeField] private GameObject _slider1;
    [SerializeField] private TMP_Text text1;

    [Space(10)]

    [SerializeField] private Slider slider2;
    [SerializeField] private GameObject _slider2;
    [SerializeField] private TMP_Text text2;

    [Space(10)]

    [SerializeField] private Slider slider3;
    [SerializeField] private GameObject _slider3;
    [SerializeField] private TMP_Text text3;

    [Space(10)]

    [SerializeField] private Slider slider4;
    [SerializeField] private GameObject _slider4;
    [SerializeField] private TMP_Text text4;

    [Space(10)]
    [Header("Controls")]
    [SerializeField] private GameObject _controls;

    [Space(10)]
    [Header("Language")]
    [SerializeField] private GameObject _language;
    [SerializeField] private GameObject frenchButton;
    [SerializeField] private GameObject englishButton;

    [Space(10)]
    [Header("Event")] 
    [SerializeField] private EventSystem _eventSystem;

    private UI controls;

    private void Awake()
    {
        controls = new UI();
        controls.Menu.escape.performed += ctx => Pause();
        controls.Menu.back.performed += ctx => Back();

        pauseMenu.SetActive(false);
        infosMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitPanel.SetActive(false);

        readable1.SetActive(false);
        readable2.SetActive(false);
        readable3.SetActive(false);
        readable4.SetActive(false);
        readable5.SetActive(false);

        _controls.SetActive(false);
        _language.SetActive(false);
        panelOption.SetActive(false);
        
        

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


    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FPC.canLook = true;
        FPC.canMove = true;
        FPC.canSidewalk = true;

    }
    public void Quit()
    {
        quitPanel.SetActive(true);
        pauseMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(noButton);
        //SceneManager.LoadScene(scene);
    }

    public void Yes()
    {
        SceneManager.LoadScene(scene);

    }
    public void No()
    {
        quitPanel.SetActive(false);
        pauseMenu.SetActive(true);
        _eventSystem.SetSelectedGameObject(quitButton);

    }
    public void Infos()
    {
        infosMenu.SetActive(true);
        pauseMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(readableButton1);
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(volumeButton);
    }


    public void Back()
    {

        if (pauseMenu.activeInHierarchy) 
        {
            Resume();
        }

        else if (quitPanel.activeInHierarchy)
        {
            quitPanel.SetActive(false);
            pauseMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(quitButton);
        }

        else if (_eventSystem.currentSelectedGameObject == _slider1 || _eventSystem.currentSelectedGameObject == _slider2 || _eventSystem.currentSelectedGameObject == _slider3 || _eventSystem.currentSelectedGameObject == _slider4)
        {
            _eventSystem.SetSelectedGameObject(volumeButton);
            panelOption.gameObject.SetActive(false);
        }
        else if (_eventSystem.currentSelectedGameObject == frenchButton || _eventSystem.currentSelectedGameObject == englishButton)
        {
            _eventSystem.SetSelectedGameObject(languageButton);
            panelOption.gameObject.SetActive(false);
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
        else if (readable5.activeInHierarchy)
        {
            readable5.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton5);
        }
        else if (infosMenu.activeInHierarchy)
        {
            infosMenu.SetActive(false);
            pauseMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(infosButton);
        }
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
    public void French()
    {
        //changer langue
    }

    public void English()
    {
        //changer langue

    }

    public void Readable1()
    {
        readable1.gameObject.SetActive(true);
        readable2.gameObject.SetActive(false);
        readable3.gameObject.SetActive(false);
        readable4.gameObject.SetActive(false);
        readable5.gameObject.SetActive(false);
        _eventSystem.SetSelectedGameObject(null);
    }

    public void Readable2()
    {
        readable1.gameObject.SetActive(false);
        readable2.gameObject.SetActive(true);
        readable3.gameObject.SetActive(false);
        readable4.gameObject.SetActive(false);
        readable5.gameObject.SetActive(false);
        _eventSystem.SetSelectedGameObject(null);
    }

    public void Readable3()
    {
        readable1.gameObject.SetActive(false);
        readable2.gameObject.SetActive(false);
        readable3.gameObject.SetActive(true);
        readable4.gameObject.SetActive(false);
        readable5.gameObject.SetActive(false);
        _eventSystem.SetSelectedGameObject(null);
    }

    public void Readable4()
    {
        readable1.gameObject.SetActive(false);
        readable2.gameObject.SetActive(false);
        readable3.gameObject.SetActive(false);
        readable4.gameObject.SetActive(true); 
        readable5.gameObject.SetActive(false);
        _eventSystem.SetSelectedGameObject(null);
    }

    public void Readable5()
    {
        readable1.gameObject.SetActive(false);
        readable2.gameObject.SetActive(false);
        readable3.gameObject.SetActive(false);
        readable4.gameObject.SetActive(false);
        readable5.gameObject.SetActive(true);
        _eventSystem.SetSelectedGameObject(null);
    }





    private void Update()
    {
        //readable found ?
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
        if (interactReadable.readable5 == true)
        {
            readableButton5.gameObject.SetActive(true);
        }

        // panel behind sliders and language buttons
        if (_eventSystem.currentSelectedGameObject == _slider1 || _eventSystem.currentSelectedGameObject == _slider2 || _eventSystem.currentSelectedGameObject == _slider3 || _eventSystem.currentSelectedGameObject == _slider4)
        {
            panelOption.gameObject.SetActive(true);
        }
        if (_eventSystem.currentSelectedGameObject == frenchButton || _eventSystem.currentSelectedGameObject == englishButton)
        {
            panelOption.gameObject.SetActive(true);
        }
        
        //sliders
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
