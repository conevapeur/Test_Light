using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject infosMenu;
    [SerializeField] private GameObject optionsMenu;

    private UI controls;

    [SerializeField] private GameObject loremIpsumButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private string scene;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        infosMenu.SetActive(false);
        optionsMenu.SetActive(false);

        controls = new UI();
        controls.Menu.escape.performed += ctx => Pause();
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
        _eventSystem.SetSelectedGameObject(loremIpsumButton);

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
