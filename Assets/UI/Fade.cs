using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float alpha;

    [SerializeField]
    private Texture oldTexture;
    [SerializeField]
    private Texture newTexture;

    [SerializeField] bool disappear;

    void Start()
    {
        target = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(target.position, transform.position);
        if (dist < 2.5 && dist >= 1 && alpha < 1)
        {
            alpha += Time.deltaTime;
            gameObject.GetComponent<RawImage>().texture = newTexture;
        }
        if (dist >= 2.5 && alpha > 0)
        {
            alpha -= Time.deltaTime;
            gameObject.GetComponent<RawImage>().texture = oldTexture;
        }
        if (dist < 1 && alpha > 0 && disappear == true)
        {
            alpha -= Time.deltaTime;

        }
        Color currColor = gameObject.GetComponent<RawImage>().color;
        currColor.a = alpha;
        gameObject.GetComponent<RawImage>().color = currColor;
    }
}