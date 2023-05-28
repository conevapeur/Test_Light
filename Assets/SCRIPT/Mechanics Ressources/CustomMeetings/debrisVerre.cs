using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class debrisVerre : MonoBehaviour
{

    public UnityEvent OnEnter;

    public Vector3 origin;

    public GameObject start;
    public GameObject point;

    //public GameObject[] decals;
    public GameObject decals;

    private bool activated;

    private Collider playerCollider;

    public float vitesseMonstre;

    

    // Start is called before the first frame update
    void Start()
    {
        origin = Vector3.Lerp(origin, transform.position, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && GameManager.instance.progression > 7)
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
        if (other.CompareTag("Player") /*&& GameManager.instance.player.GetComponent<Rigidbody>().velocity.magnitude > .7f*/)
        {
            activated = true;
            playerCollider = other;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") /*&& GameManager.instance.player.GetComponent<Rigidbody>().velocity.magnitude > .7f*/)
        {
            activated = false;

        }
    }
}
