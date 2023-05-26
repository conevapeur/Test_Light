using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIStart : MonoBehaviour
{
    [Header("Event & Buttons")]
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject creditsButton;
    [SerializeField] private GameObject volumeButton;
    [SerializeField] private GameObject controlsButton;
    [SerializeField] private GameObject languageButton;
    [SerializeField] private GameObject englishButton;
    [SerializeField] private GameObject frenchButton;
    [SerializeField] private GameObject subtitlesButton;


    [Header("Start")]
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject credits;


    [Header("Settings")]
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

    [SerializeField] private GameObject selector1;
    [SerializeField] private GameObject selector2;
    [SerializeField] private GameObject selector3;


    [SerializeField] private AudioSource audioSelected;
    [SerializeField] private AudioSource audioSelecfion;
    [SerializeField] private AudioSource audioBack;
    [SerializeField] private AudioSource audioPrincipale;
    [SerializeField] private AudioSource boom;

    [SerializeField] private UnityEvent TextFR ;
    [SerializeField] private UnityEvent TextENG; 

    
    private UI uicontrols;

    float score1 = 0;
    float score2 = 0;
    float score3 = 0;
    int left = 0;
    int right = 0;

    private bool musicFadeOutEnabled = false;
    [SerializeField] private Animator fadescreen;

    static public bool ENG = false;
    static public bool FR = true;
    static public bool SUB = true;


    

    private void Awake()
    {
        uicontrols = new UI();
        uicontrols.Menu.back.performed += ctx => Back();

        _eventSystem.SetSelectedGameObject(resumeButton);
        options.SetActive(false);
        start.SetActive(true);
        credits.SetActive(false);   

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


        uicontrols.Menu.left.performed += ctx => Left();
        uicontrols.Menu.left.canceled += ctx => StopLeft();

        uicontrols.Menu.right.performed += ctx => Right();
        uicontrols.Menu.right.canceled += ctx => StopRight();

        uicontrols.Menu.up.performed += ctx => playHoverUp();
        uicontrols.Menu.down.performed += ctx => playHoverDown();

        score1 = 50;
        score2 = 50;
        score3 = 50;

        if (ENG)
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
        if (SUB)
        {
            checkSubtitles.SetActive(true);
        }
        else
        {
            checkSubtitles.SetActive(false);

        }
    }


    void playHoverDown()
    {
        if (_eventSystem.currentSelectedGameObject == quitButton || _eventSystem.currentSelectedGameObject == languageButton || _eventSystem.currentSelectedGameObject == subtitlesButton || _eventSystem.currentSelectedGameObject == selector3) return;
        {
            audioSelecfion.Play();
            
        }
    }

    void playHoverUp()
    {
        if (_eventSystem.currentSelectedGameObject == resumeButton || _eventSystem.currentSelectedGameObject == volumeButton || _eventSystem.currentSelectedGameObject == englishButton || _eventSystem.currentSelectedGameObject == selector1) return;
        {
            audioSelecfion.Play();

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
    void Back()
    {

        if (credits.activeInHierarchy)
        {
            credits.SetActive(false);
            start.SetActive(true);
            _eventSystem.SetSelectedGameObject(creditsButton);

            audioBack.Play();

        }
        if (_eventSystem.currentSelectedGameObject == volumeButton || _eventSystem.currentSelectedGameObject == controlsButton || _eventSystem.currentSelectedGameObject == languageButton)
        {
            options.SetActive(false);
            start.SetActive(true);
            _eventSystem.SetSelectedGameObject(settingsButton);
            audioBack.Play();


        }
        else if (_eventSystem.currentSelectedGameObject == selector1 || _eventSystem.currentSelectedGameObject == selector2 || _eventSystem.currentSelectedGameObject == selector3)
        {
            _eventSystem.SetSelectedGameObject(volumeButton);
            audioBack.Play();

        }
        else if (_eventSystem.currentSelectedGameObject == frenchButton || _eventSystem.currentSelectedGameObject == englishButton || _eventSystem.currentSelectedGameObject == subtitlesButton)
        {
            _eventSystem.SetSelectedGameObject(languageButton);
            audioBack.Play();


        }



    }
    public void playSong()
    {
        audioSelected.Play();
    }
    public void playSong2()
    {
        boom.Play();
    }

    public void Play()
    {
        StartCoroutine(ButtonCoroutine());
    }
    public void Volume()
    {
        _eventSystem.SetSelectedGameObject(selector1);
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

        if (checkEnglish.activeInHierarchy == false)
        {
            checkEnglish.SetActive(true);
            checkFrench.SetActive(false);
            ENG = true; FR= false;
            TextENG.Invoke();
        }
    }
    public void French()
    {
        if (checkFrench.activeInHierarchy == false)
        {
            checkFrench.SetActive(true);
            checkEnglish.SetActive(false);
            ENG = false; FR = true;
            TextFR.Invoke();

        }

    }
    public void Subtitles()
    {

        if (checkSubtitles.activeInHierarchy)
        {
            checkSubtitles.SetActive(false);
            SUB = false;

        }
        else
        {
            checkSubtitles.SetActive(true);
            SUB = true;

        }
    }
    public void Credits()
    {
        start.SetActive(false);
        credits.SetActive(true);
        
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator ButtonCoroutine()
    {
        musicFadeOutEnabled = true;
        resumeButton.GetComponent<Button>().enabled = false;
        fadescreen.SetTrigger("trigger");

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("CINEMATIQUES");
    }



    private void Update()
    {

        if (musicFadeOutEnabled)
        {
            
            float newVolume = audioPrincipale.volume - (0.2f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
            if (newVolume < 0f)
            {
                newVolume = 0f;
            }
            audioPrincipale.volume = newVolume;
        
        }


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

        // sound

        
        


        //

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



    }

    

    private void FixedUpdate()  
    {
        if (_eventSystem.currentSelectedGameObject == selector1)
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

        if (_eventSystem.currentSelectedGameObject == selector2)
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

        if (_eventSystem.currentSelectedGameObject == selector3)
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

    private void OnEnable()
    {
        uicontrols.Menu.Enable();
    }
    private void OnDisable()
    {
        uicontrols.Menu.Disable();
    }
}
