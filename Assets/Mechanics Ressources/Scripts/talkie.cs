using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class talkie : MonoBehaviour
{

    public TextMeshPro freqTMP;
    public static float freq = 100f;
    private float x = 0.5f;

    public GameObject freqSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.O))
        {
            //freqSet.transform.rotation = Quaternion.Euler(freqSet.transform.rotation.x,freqSet.transform.rotation.y + x,freqSet.transform.rotation.z);
            freqSet.transform.Rotate(0.5f,0,0, Space.Self);
            //freqSet.transform.localEulerAngles += new Vector3(0.5f,0,0);
            freq -= 0.05f;
        }

        if(Input.GetKey(KeyCode.P))
        {
            freqSet.transform.Rotate(-0.5f,0,0, Space.Self);
            //freqSet.transform.localEulerAngles -= new Vector3(0.5f,0,0);
            freq += 0.05f;
        }
        freq = Mathf.Round(freq*100) /100;
        freqTMP.SetText(freq.ToString());
    }
}
