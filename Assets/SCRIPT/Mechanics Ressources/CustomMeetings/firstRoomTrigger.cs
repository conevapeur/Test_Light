using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class firstRoomTrigger : MonoBehaviour
{

    public UnityEvent OnEnter;

    public GameObject start;
    public GameObject point;

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
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Caller = gameObject;
            OnEnter.Invoke();
            transform.position = new Vector3(0, 50000, 0);
        }


    }
}
