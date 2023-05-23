using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class debrisVerre : MonoBehaviour
{

    public UnityEvent OnEnter;

    public GameObject start;
    public GameObject point;

    private bool activated;

    private Collider playerCollider;

    public float vitesseMonstre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && GameManager.instance.progression > 8)
        {
            //Debug.Log(activated);
            if (playerCollider.CompareTag("Player") /*&& GameManager.instance.player.GetComponent<Rigidbody>().velocity.magnitude > .7f*/)
            {
                //Debug.Log("entrée dans if");
                activated = false;
                GameManager.instance.Caller = gameObject;
                OnEnter.Invoke();
                transform.position = new Vector3(0, 50000, 0);
                //GameManager.instance.monster.GetComponent<NavMeshAgent>().acceleration = vitesseMonstre;
                //GameManager.instance.monster.GetComponent<NavMeshAgent>().angularSpeed = vitesseMonstre;
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
