using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscaladeZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.position = transform.position + new Vector3(0, 1, 0);
        }
        //Debug.Log(other.transform.tag);
    }
}
