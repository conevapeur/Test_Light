using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CineManager : MonoBehaviour
{

    private UI controls;
    int score = 0;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject skipButton;

    private void Awake()
    {
        animator.SetTrigger("triggercine");

        controls = new UI();
        controls.Menu.back.performed += ctx => Skip();
        skipButton.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("END");
    }


    void Skip()
    {
        Debug.Log("pouet");
        if (score == 0)
        {
            score += 1;
            skipButton.SetActive(true);

        }
        else
        {
            //skipButton.GetComponent<Button>().enabled = false;
            ChangeScene();
        }
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
