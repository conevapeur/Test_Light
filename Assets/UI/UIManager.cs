using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Info")]
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Slider slider1;
    [SerializeField] private Slider slider2;
    [SerializeField] private Slider slider3;
    [SerializeField] private Slider slider4;
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text text3;
    [SerializeField] private TMP_Text text4;

    private UI controls;

    [Header("Event")] // selectionner le bouton quand l'ui s'affiche
   
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private string scene;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        infosMenu.SetActive(false);
        optionsMenu.SetActive(false);

        controls = new UI();
        controls.Menu.escape.performed += ctx => Pause();

        readable1.gameObject.SetActive(false);
        readable2.gameObject.SetActive(false);
        readable3.gameObject.SetActive(false);
        readable4.gameObject.SetActive(false);
    }

    
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Pause()
    {
        if (Time.timeScale != 0f) 
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(resumeButton);
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
        infosMenu.SetActive(false);
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(resumeButton);

    }
    public void Options()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(backButton);

    }

    private void Update()
    {
        if (_eventSystem.currentSelectedGameObject == readableButton1)
        {
            if (interactReadable.readable1 == true)
            {
                readable1.gameObject.SetActive(true);
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
            }
            readable1.gameObject.SetActive(false);
            readable2.gameObject.SetActive(false);
            readable3.gameObject.SetActive(false);
        }

        text1.text = ("volume principal ") + (slider1.value * 100).ToString();
        text2.text = ("volume musique ") + (slider2.value * 100).ToString();
        text3.text = ("volume effet sonore ") + (slider3.value * 100).ToString();
        text4.text = ("volume dialogue ") + (slider4.value * 100).ToString();
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
