using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = Vector3.Lerp(origin, transform.position, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") /*&& GameManager.instance.player.GetComponent<Rigidbody>().velocity.magnitude > .7f*/)
        {
            GameManager.instance.lastCheckpoint = transform.position;

            transform.position = new Vector3(0,5000,0);
        }

    }
}
