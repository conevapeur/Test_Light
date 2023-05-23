using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class debrisVerre : MonoBehaviour
{

    public UnityEvent OnEnter;

    public GameObject start;
    public GameObject point;

    private bool activated;

    private Collider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && GameManager.instance.progression > 8)
        {
            if (playerCollider.CompareTag("Player") && GameManager.instance.player.GetComponent<Rigidbody>().velocity.magnitude > .7f)
            {
                activated = false;
                OnEnter.Invoke();
                transform.position = new Vector3(0, 50000, 0);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        activated = true;
        playerCollider = other;


    }

    private void OnTriggerExit(Collider other)
    {
        activated = false;
    }
}
