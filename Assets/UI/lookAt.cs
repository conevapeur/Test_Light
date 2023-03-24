using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    [SerializeField]
    private Transform target;
   
    

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);
        


    }


}
 