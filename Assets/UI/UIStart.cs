using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{

    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject start;
        


    private void Awake()
    {
        _eventSystem.SetSelectedGameObject(playButton);
        options.SetActive(false);
        start.SetActive(false);
    }

    public void Play()
    {
        StartCoroutine(ButtonCoroutine()); 
    }

    public void Options()
    {
        options.SetActive(true);
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
