using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_moove : MonoBehaviour
{
    public int arraySize;
    public Transform[] waypoints = new Transform[5];
    public int indice;

    [SerializeField] private float cpt;
    // Start is called before the first frame update
    void Start()
    {
        //waypoints = new Transform[arraySize];

        indice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //updatePosition();
    }

    private void OnEnable()
    {
        triggerEmit.OnTrigger += updatePosition;
    }
    private void OnDisable()
    {
        triggerEmit.OnTrigger += updatePosition;
    }

    

    private void updatePosition()
    {
        
        transform.position = waypoints[indice].position;

        indice++;
        if (indice >= arraySize)
        {
            indice = 0;
        }
        
    }
}
