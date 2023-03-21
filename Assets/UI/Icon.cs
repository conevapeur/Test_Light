using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour, IReveal
{
    [SerializeField]
    private Transform target;
    private float alpha;
    private float texture;

    [SerializeField]
    private Texture oldTexture;
    [SerializeField]
    private Texture newTexture;

    public void Reveal()
    {
        alpha = 1;
        gameObject.GetComponent<RawImage>().texture = oldTexture;
    }

    public void Switch()
    {
        gameObject.GetComponent<RawImage>().texture = newTexture;
    }
    public void Hide()
    {
        alpha = 0;
    }

    private void Update()
    {
        Color currColor = gameObject.GetComponent<RawImage>().color;
        currColor.a = alpha;
        gameObject.GetComponent<RawImage>().color = currColor;
    }

   
}
