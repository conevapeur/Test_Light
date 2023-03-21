using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float alpha;

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(target.position, transform.position);
        if (dist < 2.5 && dist >= 1 && alpha  < 1)
        {
            alpha += Time.deltaTime;
        }
        if (dist >= 2.5 && alpha > 0)
        {
            alpha -= Time.deltaTime;
        }
        if (dist < 1 && alpha > 0)
        {
            alpha -= Time.deltaTime;

        }
        Color currColor = gameObject.GetComponent<RawImage>().color;
        currColor.a = alpha;
        gameObject.GetComponent<RawImage>().color = currColor;
    }
}