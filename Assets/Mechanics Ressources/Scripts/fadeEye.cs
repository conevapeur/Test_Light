using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeEye : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float proximity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var material = gameObject.GetComponent<RawImage>().material.color.a;
        material = Mathf.InverseLerp(proximity, 0, Vector3.Distance(target.position, transform.position));

    }
}
