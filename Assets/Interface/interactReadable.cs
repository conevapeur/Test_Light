using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class interactReadable : MonoBehaviour, IInteract 
{
    public static bool readable1;
    public static bool readable2;
    public static bool readable3;
    public static bool readable4;
    public static bool card;

    [SerializeField] private int number;
    
    // Start is called before the first frame update
    void Start()
    {
        readable1 = true;
        readable2 = true;
        readable3 = true;
        readable4 = true;
        card = false;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnInteract()
    {
        Debug.Log("chien");
        Destroy(gameObject);

        if (number == 1 )
        {
            readable1= true;
        }
        if (number == 2)
        {
            readable2 = true;
        }
        if (number == 3)
        {
            readable3 = true;
        }
        if (number == 4)
        {
            readable4 = true;
        }
        if (number == 5)
        {
            card = true;
        }

    }
}
