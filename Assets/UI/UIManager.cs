using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private GameObject yesButton;


    [Space(10)]
    [Header("Readables")]
    [SerializeField] private GameObject readable1fr;
    [SerializeField] private GameObject readable2fr;
    [SerializeField] private GameObject readable3fr;
    [SerializeField] private GameObject readable4fr;
    [SerializeField] private GameObject readable5fr;
    [SerializeField] private GameObject readable1eng;
    [SerializeField] private GameObject readable2eng;
    [SerializeField] private GameObject readable3eng;
    [SerializeField] private GameObject readable4eng;
    [SerializeField] private GameObject readable5eng;

    [Space(10)]

    [SerializeField] private GameObject readableButton1;
    [SerializeField] private GameObject readableButton2;
    [SerializeField] private GameObject readableButton3;
    [SerializeField] private GameObject readableButton4;
    [SerializeField] private GameObject readableButton5;

    [Space(10)]

    [SerializeField] private GameObject readableImage1;
    [SerializeField] private GameObject readableImage2;
    [SerializeField] private GameObject readableImage3;
    [SerializeField] private GameObject readableImage4;
    [SerializeField] private GameObject readableImage5;

  

    [Space(10)]
    [Header("Option")]
    [SerializeField] private GameObject languageButton;
    [SerializeField] private GameObject volumeButton;
    [SerializeField] private GameObject controlsButton;


    [Header("Volume")]
    [SerializeField] private GameObject _volume;



    [Space(10)]
    [Header("Controls")]
    [SerializeField] private GameObject _controls;

    [Space(10)]
    [Header("Language")]
    [SerializeField] private GameObject _language;
    [SerializeField] private GameObject frenchButton;
    [SerializeField] private GameObject englishButton;
    [SerializeField] private bool eng;
    [SerializeField] private bool fr;

    [Space(10)]
    [Header("Event")]
    [SerializeField] private EventSystem _eventSystem;

    private UI controls;

    float score1 = 0;
    float score2 = 0;
    float score3 = 0;
    int left = 0;
    int right = 0;

    [SerializeField] private GameObject selector1;
    [SerializeField] private GameObject selector2;
    [SerializeField] private GameObject selector3;



    RawImage soundMark1rend1;
    RawImage soundMark2rend1;
    RawImage soundMark3rend1;
    RawImage soundMark4rend1;
    RawImage soundMark5rend1;

    RawImage soundMark1rend2;
    RawImage soundMark2rend2;
    RawImage soundMark3rend2;
    RawImage soundMark4rend2;
    RawImage soundMark5rend2;

    RawImage soundMark1rend3;
    RawImage soundMark2rend3;
    RawImage soundMark3rend3;
    RawImage soundMark4rend3;
    RawImage soundMark5rend3;

    [SerializeField] private GameObject soundMark11;
    [SerializeField] private GameObject soundMark21;
    [SerializeField] private GameObject soundMark31;
    [SerializeField] private GameObject soundMark41;
    [SerializeField] private GameObject soundMark51;

    [SerializeField] private GameObject soundMark12;
    [SerializeField] private GameObject soundMark22;
    [SerializeField] private GameObject soundMark32;
    [SerializeField] private GameObject soundMark42;
    [SerializeField] private GameObject soundMark52;

    [SerializeField] private GameObject soundMark13;
    [SerializeField] private GameObject soundMark23;
    [SerializeField] private GameObject soundMark33;
    [SerializeField] private GameObject soundMark43;
    [SerializeField] private GameObject soundMark53;


    [Header("CheckBox")]
    [SerializeField] private GameObject checkEnglish;
    [SerializeField] private GameObject checkFrench;
    [SerializeField] private GameObject checkSubtitles;
    [SerializeField] private GameObject boxEnglish;
    [SerializeField] private GameObject boxFrench;
    [SerializeField] private GameObject boxSubtitles;

    [Space(10)]
    [SerializeField] private AudioSource audioBack;
    [SerializeField] private AudioSource audioSelected;
    [SerializeField] private AudioSource audioSelecfion;

    [SerializeField] private GameObject subtitlesButton;


    [SerializeField] private UnityEvent TextFR;
    [SerializeField] private UnityEvent TextENG;

    [SerializeField] private GameObject logoCard;


    private void Awake()
    {
        controls = new UI();
        controls.Menu.escape.performed += ctx => Pause();
        controls.Menu.back.performed += ctx => Back();


        pauseMenu.SetActive(false);
        infosMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitPanel.SetActive(false);

        readable1fr.SetActive(false);
        readable2fr.SetActive(false);
        readable3fr.SetActive(false);
        readable4fr.SetActive(false);
        readable5fr.SetActive(false);

        readable1eng.SetActive(false);
        readable2eng.SetActive(false);
        readable3eng.SetActive(false);
        readable4eng.SetActive(false);
        readable5eng.SetActive(false);

        _controls.SetActive(false);
        _language.SetActive(false);


        controls.Menu.left.performed += ctx => Left();
        controls.Menu.left.canceled += ctx => StopLeft();

        controls.Menu.right.performed += ctx => Right();
        controls.Menu.right.canceled += ctx => StopRight();

        soundMark1rend1 = soundMark11.GetComponent<RawImage>();
        soundMark2rend1 = soundMark21.GetComponent<RawImage>();
        soundMark3rend1 = soundMark31.GetComponent<RawImage>(); 
        soundMark4rend1 = soundMark41.GetComponent<RawImage>();
        soundMark5rend1 = soundMark51.GetComponent<RawImage>();

        soundMark1rend2 = soundMark12.GetComponent<RawImage>();
        soundMark2rend2 = soundMark22.GetComponent<RawImage>();
        soundMark3rend2 = soundMark32.GetComponent<RawImage>();
        soundMark4rend2 = soundMark42.GetComponent<RawImage>();
        soundMark5rend2 = soundMark52.GetComponent<RawImage>();

        soundMark1rend3 = soundMark13.GetComponent<RawImage>();
        soundMark2rend3 = soundMark23.GetComponent<RawImage>();
        soundMark3rend3 = soundMark33.GetComponent<RawImage>();
        soundMark4rend3 = soundMark43.GetComponent<RawImage>();
        soundMark5rend3 = soundMark53.GetComponent<RawImage>();

        controls.Menu.up.performed += ctx => playHoverUp();
        controls.Menu.down.performed += ctx => playHoverDown();

        score1 = 50;
        score2 = 50;
        score3 = 50;

        if (UIStart.ENG)
        {
            TextENG.Invoke();
            checkFrench.SetActive(false);
            checkEnglish.SetActive(true);
        }
        else
        {
            TextFR.Invoke();
            checkEnglish.SetActive(false);
            checkFrench.SetActive(true);

        }

        readableButton1.SetActive(false);
        readableButton2.SetActive(false);
        readableButton3.SetActive(false);
        readableButton4.SetActive(false);
        readableButton5.SetActive(false);
    }

    void playHoverDown()
    {
        if ( _eventSystem.currentSelectedGameObject == quitButton || _eventSystem.currentSelectedGameObject == languageButton || _eventSystem.currentSelectedGameObject == subtitlesButton || _eventSystem.currentSelectedGameObject == selector3 || _eventSystem.currentSelectedGameObject == noButton || _eventSystem.currentSelectedGameObject == readableButton5 || _eventSystem.currentSelectedGameObject == null) return;
        {
            if (_eventSystem.currentSelectedGameObject == readableButton4 && readableButton5.activeInHierarchy == false) return;
            {
                if (_eventSystem.currentSelectedGameObject == readableButton3 && readableButton5.activeInHierarchy == false && readableButton4.activeInHierarchy == false) return;
                {
                    if (_eventSystem.currentSelectedGameObject == readableButton2 && readableButton5.activeInHierarchy == false && readableButton4.activeInHierarchy == false && readableButton3.activeInHierarchy == false) return;
                    {
                        if (_eventSystem.currentSelectedGameObject == readableButton1 && readableButton5.activeInHierarchy == false && readableButton4.activeInHierarchy == false && readableButton3.activeInHierarchy == false && readableButton2.activeInHierarchy == false) return;
                        {
                            audioSelecfion.Play();

                        }
                    }
                }
            }

        }
    }

    void playHoverUp()
    {
        if (_eventSystem.currentSelectedGameObject == resumeButton || _eventSystem.currentSelectedGameObject == volumeButton || _eventSystem.currentSelectedGameObject == englishButton || _eventSystem.currentSelectedGameObject == selector1|| _eventSystem.currentSelectedGameObject == yesButton || _eventSystem.currentSelectedGameObject == readableButton1 || _eventSystem.currentSelectedGameObject == null) return;
        {
            if (_eventSystem.currentSelectedGameObject == readableButton2 && readableButton1.activeInHierarchy == false ) return;
            {
                if (_eventSystem.currentSelectedGameObject == readableButton3 && readableButton2.activeInHierarchy == false && readableButton1.activeInHierarchy == false) return;
                {
                    if (_eventSystem.currentSelectedGameObject == readableButton4 && readableButton3.activeInHierarchy == false && readableButton2.activeInHierarchy == false && readableButton1.activeInHierarchy == false) return;
                    {
                        if (_eventSystem.currentSelectedGameObject == readableButton5 && readableButton4.activeInHierarchy == false && readableButton3.activeInHierarchy == false && readableButton2.activeInHierarchy == false && readableButton1.activeInHierarchy == false) return;
                        {
                            audioSelecfion.Play();

                        }
                    }
                }
            }
            
        }
        
        
    }
    void StopLeft()
    {
        left = 0;
    }

    void StopRight()
    {
        right = 0;
    }

    void Left()
    {


        if (_eventSystem.currentSelectedGameObject == selector1 || _eventSystem.currentSelectedGameObject == selector2 || _eventSystem.currentSelectedGameObject == selector3)
        {
            left = 1;

        }
    }
    void Right()
    {
        if (_eventSystem.currentSelectedGameObject == selector1 || _eventSystem.currentSelectedGameObject == selector2 || _eventSystem.currentSelectedGameObject == selector3)
        {
            right = 1;
        }
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
        audioSelected.Play();
    }

    public void Yes()
    {
        SceneManager.LoadScene(scene);
        audioSelected.Play();

    }
    public void No()
    {
        quitPanel.SetActive(false);
        pauseMenu.SetActive(true);
        _eventSystem.SetSelectedGameObject(quitButton);
        audioSelected.Play();

    }
    public void Infos()
    {
        audioSelected.Play();

        infosMenu.SetActive(true);
        pauseMenu.SetActive(false);
        

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

        if (interactReadable.readable1 == true)
        {
            _eventSystem.SetSelectedGameObject(readableButton1);
        }
        else if(interactReadable.readable1 == false && interactReadable.readable2 == true) 
        {
            _eventSystem.SetSelectedGameObject(readableButton2);

        }
        else if (interactReadable.readable1 == false && interactReadable.readable2 == false && interactReadable.readable3 == true)
        {
            _eventSystem.SetSelectedGameObject(readableButton3);

        }
        else if (interactReadable.readable1 == false && interactReadable.readable2 == false && interactReadable.readable3 == false && interactReadable.readable4 == true)
        {
            _eventSystem.SetSelectedGameObject(readableButton4);

        }
        else if (interactReadable.readable1 == false && interactReadable.readable2 == false && interactReadable.readable3 == false && interactReadable.readable4 == false && interactReadable.readable5 == true)
        {
            _eventSystem.SetSelectedGameObject(readableButton5);

        }
        else
        {
            _eventSystem.SetSelectedGameObject(null);

        }
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(volumeButton);
        _volume.SetActive(true);
        audioSelected.Play();

    }

    public void Back()
    {

        if (pauseMenu.activeInHierarchy)
        {
            Resume();
            audioBack.Play();

        }

        else if (quitPanel.activeInHierarchy)
        {
            quitPanel.SetActive(false);
            pauseMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(quitButton);
            audioBack.Play();

        }


        else if (_eventSystem.currentSelectedGameObject == frenchButton || _eventSystem.currentSelectedGameObject == englishButton)
        {
            _eventSystem.SetSelectedGameObject(languageButton);
            audioBack.Play();

        }
        else if (_eventSystem.currentSelectedGameObject == selector1 || _eventSystem.currentSelectedGameObject == selector2 || _eventSystem.currentSelectedGameObject == selector3)
        {
            _eventSystem.SetSelectedGameObject(volumeButton);
            audioBack.Play();

        }

        else if (optionsMenu.activeInHierarchy)
        {
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(true);
            audioBack.Play();

            _eventSystem.SetSelectedGameObject(optionButton);
        }




        else if (readable1fr.activeInHierarchy || readable1eng.activeInHierarchy)
        {
            audioBack.Play();

            readable1fr.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton1);
        }
        else if (readable2fr.activeInHierarchy || readable2eng.activeInHierarchy)
        {
            audioBack.Play();

            readable2fr.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton2);
        }
        else if (readable3fr.activeInHierarchy || readable3eng.activeInHierarchy)
        {
            audioBack.Play();

            readable3fr.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton3);
        }
        else if (readable4fr.activeInHierarchy || readable4eng.activeInHierarchy)
        {
            audioBack.Play();

            readable4fr.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton4);
        }
        else if (readable5fr.activeInHierarchy || readable5eng.activeInHierarchy)
        {
            audioBack.Play();

            readable5fr.SetActive(false);
            _eventSystem.SetSelectedGameObject(readableButton5);
        }
        else if (infosMenu.activeInHierarchy)
        {
            audioBack.Play();

            infosMenu.SetActive(false);
            pauseMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(infosButton);
        }
    }


    public void Volume()
    {
        _eventSystem.SetSelectedGameObject(selector1);
        audioSelected.Play();


    }
    public void Controls()
    {

    }
    public void Language()
    {
        _eventSystem.SetSelectedGameObject(englishButton);
        audioSelected.Play();

    }

    public void English()
    {
        audioSelected.Play();


        if (checkEnglish.activeInHierarchy == false)
        {
            checkEnglish.SetActive(true);
            checkFrench.SetActive(false);
            UIStart.ENG = true; UIStart.FR = false;
            TextENG.Invoke();
        }
    }
    public void French()
    {
        audioSelected.Play();

        if (checkFrench.activeInHierarchy == false)
        {
            checkFrench.SetActive(true);
            checkEnglish.SetActive(false);
            UIStart.ENG = false; UIStart.FR = true;
            TextFR.Invoke();
        }

    }
    public void Subtitles()
    {
        audioSelected.Play();

        if (checkSubtitles.activeInHierarchy)
        {
            checkSubtitles.SetActive(false);

        }
        else
        {
            checkSubtitles.SetActive(true);
        }
    }

    /*
    public void ButtonLanguage()//On Button Click
    {
        if (LocalizationSystem.instance.currentLanguage == 0)//if next lang available
        {

            LocalizationSystem.instance.currentLanguage = 1;
            LocalizationSystem.instance.Init();
        }
        else//loop
        {

            LocalizationSystem.instance.currentLanguage = 0;
            LocalizationSystem.instance.Init();

        }
        StartCoroutine("LoadingNewLanguage");//wait before reloading scene
    }
    

    private IEnumerator LoadingNewLanguage()
    {
        while (!LocalizationSystem.instance.isReady)
        {
            yield return null;//wait
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reload scene


    }

    */
    public void Readable1()
    {
        audioSelected.Play();
        if (UIStart.ENG)
        {
            readable1eng.gameObject.SetActive(true);
            readable2eng.gameObject.SetActive(false);
            readable3eng.gameObject.SetActive(false);
            readable4eng.gameObject.SetActive(false);
            readable5eng.gameObject.SetActive(false);
        }
        else
        {
            readable1fr.gameObject.SetActive(true);
            readable2fr.gameObject.SetActive(false);
            readable3fr.gameObject.SetActive(false);
            readable4fr.gameObject.SetActive(false);
            readable5fr.gameObject.SetActive(false);
        }
        
        _eventSystem.SetSelectedGameObject(null);
    }

    public void Readable2()
    {
        audioSelected.Play();

        if (UIStart.ENG)
        {
            readable1eng.gameObject.SetActive(false);
            readable2eng.gameObject.SetActive(true);
            readable3eng.gameObject.SetActive(false);
            readable4eng.gameObject.SetActive(false);
            readable5eng.gameObject.SetActive(false);
        }
        else
        {
            readable1fr.gameObject.SetActive(false);
            readable2fr.gameObject.SetActive(true);
            readable3fr.gameObject.SetActive(false);
            readable4fr.gameObject.SetActive(false);
            readable5fr.gameObject.SetActive(false);
        }
        _eventSystem.SetSelectedGameObject(null);
    }

    public void Readable3()
    {
        audioSelected.Play();

        if (UIStart.ENG)
        {
            readable1eng.gameObject.SetActive(false);
            readable2eng.gameObject.SetActive(false);
            readable3eng.gameObject.SetActive(true);
            readable4eng.gameObject.SetActive(false);
            readable5eng.gameObject.SetActive(false);
        }
        else
        {
            readable1fr.gameObject.SetActive(false);
            readable2fr.gameObject.SetActive(false);
            readable3fr.gameObject.SetActive(true);
            readable4fr.gameObject.SetActive(false);
            readable5fr.gameObject.SetActive(false);
        }
        _eventSystem.SetSelectedGameObject(null);
    }

    public void Readable4()
    {
        audioSelected.Play();

        if (UIStart.ENG)
        {
            readable1eng.gameObject.SetActive(false);
            readable2eng.gameObject.SetActive(false);
            readable3eng.gameObject.SetActive(false);
            readable4eng.gameObject.SetActive(true);
            readable5eng.gameObject.SetActive(false);
        }
        else
        {
            readable1fr.gameObject.SetActive(false);
            readable2fr.gameObject.SetActive(false);
            readable3fr.gameObject.SetActive(false);
            readable4fr.gameObject.SetActive(true);
            readable5fr.gameObject.SetActive(false);
        }
        _eventSystem.SetSelectedGameObject(null);
    }

    public void Readable5()
    {
        audioSelected.Play();

        if (UIStart.ENG)
        {
            readable1eng.gameObject.SetActive(false);
            readable2eng.gameObject.SetActive(false);
            readable3eng.gameObject.SetActive(false);
            readable4eng.gameObject.SetActive(false);
            readable5eng.gameObject.SetActive(true);
        }
        else
        {
            readable1fr.gameObject.SetActive(false);
            readable2fr.gameObject.SetActive(false);
            readable3fr.gameObject.SetActive(false);
            readable4fr.gameObject.SetActive(false);
            readable5fr.gameObject.SetActive(true);
        }
        _eventSystem.SetSelectedGameObject(null);
    }


    private void Update()
    {
    
        if (_eventSystem.currentSelectedGameObject == volumeButton && !_volume.activeInHierarchy)
        {
            _volume.SetActive(true);
            _controls.SetActive(false);
            _language.SetActive(false);
        }

        if (_eventSystem.currentSelectedGameObject == controlsButton && !_controls.activeInHierarchy)
        {
            _volume.SetActive(false);
            _controls.SetActive(true);
            _language.SetActive(false);
        }

        if (_eventSystem.currentSelectedGameObject == languageButton && !_language.activeInHierarchy)
        {
            _volume.SetActive(false);
            _controls.SetActive(false);
            _language.SetActive(true);
        }

        if (score1 < 20)
        {
            var tempColor = soundMark1rend1.color;
            tempColor.a = score1 / 20;
            soundMark1rend1.color = tempColor;
            soundMark11.SetActive(true);
            soundMark21.SetActive(false);
            soundMark31.SetActive(false);
            soundMark41.SetActive(false);
            soundMark51.SetActive(false);
        }
        else if (score1 < 40)
        {
            var tempColor = soundMark2rend1.color;
            tempColor.a = (score1 - 20) / 20;
            soundMark2rend1.color = tempColor;
            soundMark11.SetActive(true);
            soundMark21.SetActive(true);
            soundMark31.SetActive(false);
            soundMark41.SetActive(false);
            soundMark51.SetActive(false);

        }
        else if (score1 < 60)
        {
            var tempColor = soundMark3rend1.color;
            tempColor.a = (score1 - 40) / 20;
            soundMark3rend1.color = tempColor;
            soundMark11.SetActive(true);
            soundMark21.SetActive(true);
            soundMark31.SetActive(true);
            soundMark41.SetActive(false);
            soundMark51.SetActive(false);

        }
        else if (score1 < 80)
        {
            var tempColor = soundMark4rend1.color;
            tempColor.a = (score1 - 60) / 20;
            soundMark4rend1.color = tempColor;
            soundMark11.SetActive(true);
            soundMark21.SetActive(true);
            soundMark31.SetActive(true);
            soundMark41.SetActive(true);
            soundMark51.SetActive(false);

        }
        else if (score1 < 100)
        {
            var tempColor = soundMark5rend1.color;
            tempColor.a = (score1 - 80) / 20;
            soundMark5rend1.color = tempColor;
            soundMark11.SetActive(true);
            soundMark21.SetActive(true);
            soundMark31.SetActive(true);
            soundMark41.SetActive(true);
            soundMark51.SetActive(true);

        }

        if (score2 < 20)
        {
            var tempColor = soundMark1rend2.color;
            tempColor.a = score2 / 20;
            soundMark1rend2.color = tempColor;
            soundMark12.SetActive(true);
            soundMark22.SetActive(false);
            soundMark32.SetActive(false);
            soundMark42.SetActive(false);
            soundMark52.SetActive(false);
        }
        else if (score2 < 40)
        {
            var tempColor = soundMark2rend2.color;
            tempColor.a = (score2 - 20) / 20;
            soundMark2rend2.color = tempColor;
            soundMark12.SetActive(true);
            soundMark22.SetActive(true);
            soundMark32.SetActive(false);
            soundMark42.SetActive(false);
            soundMark52.SetActive(false);

        }

        //Debug.Log(score);

        else if (score2 < 60)
        {
            var tempColor = soundMark3rend2.color;
            tempColor.a = (score2 - 40) / 20;
            soundMark3rend2.color = tempColor;
            soundMark12.SetActive(true);
            soundMark22.SetActive(true);
            soundMark32.SetActive(true);
            soundMark42.SetActive(false);
            soundMark52.SetActive(false);

        }
        else if (score2 < 80)
        {
            var tempColor = soundMark4rend2.color;
            tempColor.a = (score2 - 60) / 20;
            soundMark4rend2.color = tempColor;
            soundMark12.SetActive(true);
            soundMark22.SetActive(true);
            soundMark32.SetActive(true);
            soundMark42.SetActive(true);
            soundMark52.SetActive(false);

        }
        else if (score2 < 100)
        {
            var tempColor = soundMark5rend2.color;
            tempColor.a = (score2 - 80) / 20;
            soundMark5rend2.color = tempColor;
            soundMark12.SetActive(true);
            soundMark22.SetActive(true);
            soundMark32.SetActive(true);
            soundMark42.SetActive(true);
            soundMark52.SetActive(true);

        }

        if (score3 < 20)
        {
            var tempColor = soundMark1rend3.color;
            tempColor.a = score3 / 20;
            soundMark1rend3.color = tempColor;
            soundMark13.SetActive(true);
            soundMark23.SetActive(false);
            soundMark33.SetActive(false);
            soundMark43.SetActive(false);
            soundMark53.SetActive(false);
        }
        else if (score3 < 40)
        {
            var tempColor = soundMark2rend3.color;
            tempColor.a = (score3 - 20) / 20;
            soundMark2rend3.color = tempColor;
            soundMark13.SetActive(true);
            soundMark23.SetActive(true);
            soundMark33.SetActive(false);
            soundMark43.SetActive(false);
            soundMark53.SetActive(false);

        }
        else if (score3 < 60)
        {
            var tempColor = soundMark3rend3.color;
            tempColor.a = (score3 - 40) / 20;
            soundMark3rend3.color = tempColor;
            soundMark13.SetActive(true);
            soundMark23.SetActive(true);
            soundMark33.SetActive(true);
            soundMark43.SetActive(false);
            soundMark53.SetActive(false);

        }
        else if (score3 < 80)
        {
            var tempColor = soundMark4rend3.color;
            tempColor.a = (score3 - 60) / 20;
            soundMark4rend3.color = tempColor;
            soundMark13.SetActive(true);
            soundMark23.SetActive(true);
            soundMark33.SetActive(true);
            soundMark43.SetActive(true);
            soundMark53.SetActive(false);

        }
        else if (score3 < 100)
        {
            var tempColor = soundMark5rend3.color;
            tempColor.a = (score3 - 80) / 20;
            soundMark5rend3.color = tempColor;
            soundMark13.SetActive(true);
            soundMark23.SetActive(true);
            soundMark33.SetActive(true);
            soundMark43.SetActive(true);
            soundMark53.SetActive(true);

        }

        if (_eventSystem.currentSelectedGameObject==selector1) 
        {
            if (right == 1 && score1 < 100)
            {
                score1 += 0.5f;
            }
            if (left == 1 && score1 > 0)
            {
                score1 -= 0.5f;
            }
        }

        if (_eventSystem.currentSelectedGameObject==selector2)
        {
            if (right == 1 && score2 < 100)
            {
                score2 += 0.5f;
            }
            if (left == 1 && score2 > 0)
            {
                score2 -= 0.5f;
            }
        }

        if (_eventSystem.currentSelectedGameObject==selector3)
        {
            if (right == 1 && score3 < 100)
            {
                score3 += 0.5f;
            }
            if (left == 1 && score3 > 0)
            {
                score3 -= 0.5f;
            }
        }


        if (_eventSystem.currentSelectedGameObject == readableButton1)
        {
            readableImage1.SetActive(true);
            readableImage2.SetActive(false);
            readableImage3.SetActive(false);
            readableImage4.SetActive(false);
            readableImage5.SetActive(false);
        }
        if (_eventSystem.currentSelectedGameObject == readableButton2)
        {
            readableImage1.SetActive(false);
            readableImage2.SetActive(true);
            readableImage3.SetActive(false);
            readableImage4.SetActive(false);
            readableImage5.SetActive(false);

        }
        if (_eventSystem.currentSelectedGameObject == readableButton3)
        {
            readableImage1.SetActive(false);
            readableImage2.SetActive(false);
            readableImage3.SetActive(true);
            readableImage4.SetActive(false);
            readableImage5.SetActive(false);
        }
        if (_eventSystem.currentSelectedGameObject == readableButton4)
        {
            readableImage1.SetActive(false);
            readableImage2.SetActive(false);
            readableImage3.SetActive(false);
            readableImage4.SetActive(true);
            readableImage5.SetActive(false);
        }
        if (_eventSystem.currentSelectedGameObject == readableButton5)
        {
            readableImage1.SetActive(false);
            readableImage2.SetActive(false);
            readableImage3.SetActive(false);
            readableImage4.SetActive(false);
            readableImage5.SetActive(true);
        }


        if (interactReadable.card == true)
        {
            logoCard.SetActive(true);
        }
        else
        {
            logoCard.SetActive(false);
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
