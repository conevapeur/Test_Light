using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject infosMenu;

    private UI controls;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        infosMenu.SetActive(false);

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
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Infos()
    {
        infosMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Back()
    {
        infosMenu.SetActive(false);
        pauseMenu.SetActive(true);
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
