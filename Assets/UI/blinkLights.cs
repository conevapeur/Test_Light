using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkLights : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Light light1;
    [SerializeField] Light light2;
    [SerializeField] Light light3;

    [SerializeField] private Animator animator;
    void Start()
    {
        StartCoroutine(Waiter());
    }

    

    IEnumerator Waiter()
    {
        int wait_time = Random.Range(5, 15);
        yield return new WaitForSeconds(wait_time);
        StartCoroutine(Blink());
    }
    IEnumerator Blink()
    {


        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        yield return new WaitForSeconds(0.05f);
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        yield return new WaitForSeconds(1f);

        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        yield return new WaitForSeconds(0.1f);
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        yield return new WaitForSeconds(0.2f);

        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        yield return new WaitForSeconds(0.1f);
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;

        yield return new WaitForSeconds(0.3f);
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        light1.intensity = 0;
        light2.intensity = 0;
        light3.intensity = 0;
        yield return new WaitForSeconds(0.02f);
        animator.SetTrigger("trigger");

        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        
       
        yield return new WaitForSeconds(1f);
        


        StartCoroutine(Waiter());

    }
}
