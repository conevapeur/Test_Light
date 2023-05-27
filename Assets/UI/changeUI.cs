using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeUI : MonoBehaviour
{

    [SerializeField] GameObject oldOne;
    [SerializeField] GameObject newOne;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zonechnageUI"))
        {
            oldOne.SetActive(false);
            newOne.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("zonechnageUI"))
        {
            oldOne.SetActive(true);
            newOne.SetActive(false);
        }
    }
}
