using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class interactGenerator : MonoBehaviour, IInteract
{
    LightmapData[] _lightmapData;

    [SerializeField] private AudioSource generator;

    [SerializeField] private GameObject objet1;
    [SerializeField] private GameObject objet2;

    [SerializeField] private Animator levier;

    [SerializeField] private GameObject chaise;

    

    // Start is called before the first frame update
    void Start()
    {
        _lightmapData = LightmapSettings.lightmaps;
        LightmapSettings.lightmaps = new LightmapData[] { };
        objet2.SetActive(false);
    }

    // Update is called once per frame
    public void OnInteract()
    {
        Debug.Log("generateur allumé");

        LightmapSettings.lightmaps = _lightmapData;

        //_stairs.SetTrigger("trigger"); --------------------------------------------------------------

        levier.SetTrigger("trigger");

        generator.Play();

        objet2.SetActive(true);
        objet1.SetActive(false);

        GameManager.instance.player.transform.position += new Vector3(50, 0, 0);

        chaise.transform.position += new Vector3(50, 0, 0);







    }
}
