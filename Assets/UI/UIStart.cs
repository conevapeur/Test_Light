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
    [SerializeField] private GameObject settingsButton;
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
    
    [SerializeField] private GameObject soundMark1;
    [SerializeField] private GameObject soundMark2;
    [SerializeField] private GameObject soundMark3;
    [SerializeField] private GameObject soundMark4;
    [SerializeField] private GameObject soundMark5;


    RawImage soundMark1rend;
    RawImage soundMark2rend;
    RawImage soundMark3rend;
    RawImage soundMark4rend;
    RawImage soundMark5rend;



    private UI uicontrols;

    float score = 0;
    int left = 0;
    int right = 0;

    private void Awake()
    {
        uicontrols = new UI();
        uicontrols.Menu.back.performed += ctx => Back();

        _eventSystem.SetSelectedGameObject(resumeButton);
        options.SetActive(false);
        start.SetActive(true);

        soundMark1rend = soundMark1.GetComponent<RawImage>();
        soundMark2rend = soundMark2.GetComponent<RawImage>();
        soundMark3rend = soundMark3.GetComponent<RawImage>();
        soundMark4rend = soundMark4.GetComponent<RawImage>();
        soundMark5rend = soundMark5.GetComponent<RawImage>();


        uicontrols.Menu.left.performed += ctx => Left();
        uicontrols.Menu.left.canceled += ctx => StopLeft();

        uicontrols.Menu.right.performed += ctx => Right();
        uicontrols.Menu.right.canceled += ctx => StopRight();
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
        if (_eventSystem.currentSelectedGameObject == soundMark1)
        {
            left = 1;

        }
    }
    void Right()
    {
        if (_eventSystem.currentSelectedGameObject == soundMark1)
        {
            right = 1;

        }
    }
    void Back()
    {
       
        if (_eventSystem.currentSelectedGameObject == volumeButton || _eventSystem.currentSelectedGameObject == controlsButton || _eventSystem.currentSelectedGameObject == languageButton)
        {
            options.SetActive(false);
            start.SetActive(true);
            _eventSystem.SetSelectedGameObject(settingsButton);

        }
        if (_eventSystem.currentSelectedGameObject == soundMark1)
        {
            _eventSystem.SetSelectedGameObject(volumeButton);
        }
        if (_eventSystem.currentSelectedGameObject == frenchButton || _eventSystem.currentSelectedGameObject == englishButton || _eventSystem.currentSelectedGameObject == subtitlesButton)
        {
            _eventSystem.SetSelectedGameObject(languageButton);

        }


    }

    public void Play()
    {
        StartCoroutine(ButtonCoroutine()); 
    }
    public void Volume()
    {
        _eventSystem.SetSelectedGameObject(soundMark1);
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
        SceneManager.LoadScene("");
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
        
        //

        if (score < 20)
        {
            var tempColor1 = soundMark1rend.color;
            tempColor1.a = score/20;
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
            tempColor2.a = (score -20) / 20;
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



    }

    private void FixedUpdate()
    {
        if (right == 1 && score<100)
        {
            score += 0.5f;
        }
        if (left == 1 && score > 0)
        {
            score -= 0.5f;
     
        }
        Debug.Log(score);
    }

    private void OnEnable()
    {
        uicontrols.Menu.Enable();
    }
    private void OnDisable()
    {
        uicontrols.Menu.Disable();
    }
}
