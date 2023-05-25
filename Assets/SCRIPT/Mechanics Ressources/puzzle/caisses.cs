using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caisses : MonoBehaviour
{
    private Collider co;



    // Start is called before the first frame update
    void Start()
    {
        co = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(co.bounds.center , (Vector3.up * -1), Color.yellow);
        if (Physics.Raycast(co.bounds.center + new Vector3(.5f, 0, .5f) , (Vector3.up *-1), out hit, Mathf.Infinity))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(Mathf.Abs(hit.point.y - co.bounds.center.y) > Mathf.Abs(co.bounds.max.y - co.bounds.min.y) + .02f)
            {
                transform.position -= new Vector3(0, Time.deltaTime, 0);
            }
        }
    }
}
