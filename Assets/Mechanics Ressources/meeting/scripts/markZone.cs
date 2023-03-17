using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class markZone : MonoBehaviour
{
    public GameObject monster;
    public GameObject aSpot;

    public bool isTriggered;
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

            if(isTriggered == false)
            {
                isTriggered = true;
                StartCoroutine(visit());
            }
            //Debug.Log(other.GetComponent<FPC>().isCrouching);  
        }
        //Debug.Log(other.transform.tag);
    }

    IEnumerator visit()
    {
        
        yield return new WaitForSeconds(5);

        monster.transform.position = aSpot.transform.position + new Vector3(0,1,0);
        monster.GetComponent<s_monster>().isLooking = true;

        yield return new WaitForSeconds(5);

        monster.transform.position = new Vector3(0, -100, 0);
        monster.GetComponent<s_monster>().isLooking = false;
        isTriggered = false;
        
        
    }
}
