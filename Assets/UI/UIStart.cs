using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{



    [SerializeField] private string scene;

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
        SceneManager.LoadScene(scene);

    }
}
