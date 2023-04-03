using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class talkie : MonoBehaviour
{

    public TextMeshPro freqTMP;
    public static float freq = 100f;
    private float x = 0.5f;

    public GameObject freqSet;



    

    public AudioSource myAudioSource;
    public AudioSource noise;
    public GameObject target;
    public int maxDist = 50;
    private int minDist = 10;

    public int state = 0;

    public int curFreq = 0;

    public float cap = 0;


    [SerializeField] private Animator _animator;


    
    // Start is called before the first frame update
    void Start()
    {
        
        //myAudioSource = GetComponent<AudioSource>();
        StartCoroutine(changeCurFreq());
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        */

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            state -= 1;
            if (state < 0)
                state = 4;
            
            refreshFreq();

            _animator.SetTrigger("trigger");
        }
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            state += 1;
            state = state % 5;

            refreshFreq();

            _animator.SetTrigger("trigger");

        }

        //Debug.Log(Vector3.Distance(target.transform.position, transform.position));

        setVolume();
    }

    private void refreshFreq()
    {
        switch(state)
        {
            case 0:
                Debug.Log(state + 1);
                freqTMP.SetText("preset 1");
                break;
            case 1:
                Debug.Log(state + 1);
                freqTMP.SetText("preset 2");
                break;
            case 2:
                Debug.Log(state + 1);
                freqTMP.SetText("preset 3");
                break;
            case 3:
                Debug.Log(state + 1);
                freqTMP.SetText("preset 4");
                break;
            case 4:
                Debug.Log(state + 1);
                freqTMP.SetText("preset 5");
                break;
            default:
                break;
        }

    }

    private void setVolume()
    {
        setCap();
        
        /*if(state == curFreq)
        {
            myAudioSource.volume = cap;
        }
        else if (state == curFreq -1 || state == curFreq+1)
        {
            myAudioSource.volume = cap / 2;
            noise.volume = cap / 2;
        }
        else
        {
            myAudioSource.volume = cap/10;
            noise.volume = 9*cap/10;

        }*/

        myAudioSource.volume = cap / Mathf.Pow(2, Mathf.Abs(state - curFreq)) - cap/10;
        noise.volume = cap - myAudioSource.volume + cap/10;
    }

    private void setCap()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist > maxDist)
        {
            cap = 0;
        }
        else if (dist < minDist)
        {
            cap = 1;
        }
        else if (dist > minDist && dist < maxDist)
        {
            
            cap = 1 - (dist - minDist) / (maxDist - minDist);
            
        }
        cap = cap / 2;
    }

    IEnumerator changeCurFreq()
    {
        int temp;
        while (true)
        {
            do
            {
                temp = Random.Range(0, 5);
            }
            while (temp == curFreq);

            //curFreq = temp;

            yield return new WaitForSeconds(5);
        }
        
        
    }

    
}
