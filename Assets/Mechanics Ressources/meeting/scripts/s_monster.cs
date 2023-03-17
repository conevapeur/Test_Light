using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_monster : MonoBehaviour
{
    public bool isLooking;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLooking)
        {
            if(player.GetComponent<FPC>().isCrouching == false)
            {
                Debug.Log("TU ES MORT");
            }
            else
            {
                Debug.Log("TU ES EN SECURITE");
            }
        }
    }
}
