using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph;
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

    float score = 0;
    int left = 0;
    int right = 0;

    RawImage soundMark1rend;
    RawImage soundMark2rend;
    RawImage soundMark3rend;
    RawImage soundMark4rend;
    RawImage soundMark5rend;

    [SerializeField] private GameObject soundMark1;
    [SerializeField] private GameObject soundMark2;
    [SerializeField] private GameObject soundMark3;
    [SerializeField] private GameObject soundMark4;
    [SerializeField] private GameObject soundMark5;


    [Header("CheckBox")]
    [SerializeField] private GameObject checkEnglish;
    [SerializeField] private GameObject checkFrench;
    [SerializeField] private GameObject checkSubtitles;
    [SerializeField] private GameObject boxEnglish;
    [SerializeField] private GameObject boxFrench;
    [SerializeField] private GameObject boxSubtitles;

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
        

        controls.Menu.left.performed += ctx => Left();
        controls.Menu.left.canceled += ctx => StopLeft();

        controls.Menu.right.performed += ctx => Right();
        controls.Menu.right.canceled += ctx => StopRight();

        soundMark1rend = soundMark1.GetComponent<RawImage>();
        soundMark2rend = soundMark2.GetComponent<RawImage>();
        soundMark3rend = soundMark3.GetComponent<RawImage>();
        soundMark4rend = soundMark4.GetComponent<RawImage>();
        soundMark5rend = soundMark5.GetComponent<RawImage>();

        score = 50;
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
        Debug.Log("1/2");

        if (_eventSystem.currentSelectedGameObject == soundMark1)
        {
            left = 1;
            Debug.Log("2/2");
        }
    }
    void Right()
    {
        if (_eventSystem.currentSelectedGameObject == soundMark1)
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
        _volume.SetActive(true);
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

        
        else if (_eventSystem.currentSelectedGameObject == frenchButton || _eventSystem.currentSelectedGameObject == englishButton)
        {
            _eventSystem.SetSelectedGameObject(languageButton);
        }
        else if (_eventSystem.currentSelectedGameObject == soundMark1)
        {
            _eventSystem.SetSelectedGameObject(volumeButton);
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
        _eventSystem.SetSelectedGameObject(soundMark1);
       
    }
    public void Controls()
    {

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

        if (score < 20)
        {
            var tempColor1 = soundMark1rend.color;
            tempColor1.a = score / 20;
            soundMark1rend.color = tempColor1;
            soundMark1.SetActive(true);

            soundMark2.SetActive(false);
            soundMark3.SetActive(false);
            soundMark4.SetActive(false);
            soundMark5.SetActive(false);
        }
        else if (score < 40)
        {
            var tempColor2 = soundMark2rend.color;
            tempColor2.a = (score - 20) / 20;
            soundMark2rend.color = tempColor2;
            soundMark1.SetActive(true);
            soundMark2.SetActive(true);
            soundMark3.SetActive(false);
            soundMark4.SetActive(false);
            soundMark5.SetActive(false);

        }
        else if (score < 60)
        {
            var tempColor3 = soundMark3rend.color;
            tempColor3.a = (score - 40) / 20;
            soundMark3rend.color = tempColor3;
            soundMark1.SetActive(true);
            soundMark2.SetActive(true);
            soundMark3.SetActive(true);
            soundMark4.SetActive(false);
            soundMark5.SetActive(false);

        }
        else if (score < 80)
        {
            var tempColor4 = soundMark4rend.color;
            tempColor4.a = (score - 60) / 20;
            soundMark4rend.color = tempColor4;
            soundMark1.SetActive(true);
            soundMark2.SetActive(true);
            soundMark3.SetActive(true);
            soundMark4.SetActive(true);
            soundMark5.SetActive(false);

        }
        else if (score < 100)
        {
            var tempColor5 = soundMark5rend.color;
            tempColor5.a = (score - 80) / 20;
            soundMark5rend.color = tempColor5;
            soundMark1.SetActive(true);
            soundMark2.SetActive(true);
            soundMark3.SetActive(true);
            soundMark4.SetActive(true);
            soundMark5.SetActive(true);

        }

        if (right == 1 && score < 100)
        {
            score += 0.5f;
        }
        if (left == 1 && score > 0)
        {
            score -= 0.5f;

        }
        //Debug.Log(score);

    }

    private void FixedUpdate()
    {
        
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
