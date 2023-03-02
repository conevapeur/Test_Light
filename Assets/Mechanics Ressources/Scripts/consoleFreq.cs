using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleFreq : MonoBehaviour
{
    public Material M1;
    public Material M2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(talkie.freq < 100)
        {
            gameObject.GetComponent<MeshRenderer>().material = M1;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = M2;
        }
    }
}
