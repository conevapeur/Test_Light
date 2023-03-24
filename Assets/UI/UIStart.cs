using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{

    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameObject playButton;


    private void Awake()
    {
        _eventSystem.SetSelectedGameObject(playButton);
        Time.timeScale = 1f;
    }

    public void Play()
    {
        StartCoroutine(ButtonCoroutine());
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator ButtonCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("TEST LD");

    }
}
