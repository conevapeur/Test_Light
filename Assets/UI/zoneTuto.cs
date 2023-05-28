using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneTuto : MonoBehaviour
{

    [SerializeField] private GameObject moveTuto;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveTuto.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveTuto.SetActive(false);
        }
    }
}
