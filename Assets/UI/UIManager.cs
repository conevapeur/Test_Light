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


    [Space(10)]
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

        score1 = 50;
        score2 = 50;
        score3 = 50;

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
        else if (_eventSystem.currentSelectedGameObject == selector1 || _eventSystem.currentSelectedGameObject == selector2 || _eventSystem.currentSelectedGameObject == selector3)
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
        _eventSystem.SetSelectedGameObject(selector1);

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
