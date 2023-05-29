using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") /*&& GameManager.instance.player.GetComponent<Rigidbody>().velocity.magnitude > .7f*/)
        {
            GameManager.instance.Die();
            


        }

    }

}
