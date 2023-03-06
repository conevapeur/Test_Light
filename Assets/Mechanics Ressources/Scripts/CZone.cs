using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CZone : MonoBehaviour
{

    public FPC script;

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
            GameObject eyes = other.GetComponent<FPC>().joint;
            if(other.GetComponent<FPC>().isCrouching == false)
            {
                other.GetComponent<FPC>().isCrouching = true;
                eyes.transform.position = new Vector3(eyes.transform.position.x, eyes.transform.position.y - 0.75f ,eyes.transform.position.z);
            }
            //Debug.Log(other.GetComponent<FPC>().isCrouching);  
        }
        //Debug.Log(other.transform.tag);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameObject eyes = other.GetComponent<FPC>().joint;
            if(other.GetComponent<FPC>().isCrouching == true)
            {
                other.GetComponent<FPC>().isCrouching = false;
                eyes.transform.position = new Vector3(eyes.transform.position.x,eyes.transform.position.y + 0.75f, eyes.transform.position.z);
            }
        }
        //Debug.Log(other.transform.tag);
    }
}
