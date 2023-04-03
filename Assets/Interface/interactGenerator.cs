using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactGenerator : MonoBehaviour, IInteract
{
    LightmapData[] _lightmapData;

    [SerializeField] private Animator _stairs;
    

    // Start is called before the first frame update
    void Start()
    {
        _lightmapData = LightmapSettings.lightmaps;
        LightmapSettings.lightmaps = new LightmapData[] { };
    }

    // Update is called once per frame
    public void OnInteract()
    {
        Debug.Log("chien");
        LightmapSettings.lightmaps = _lightmapData;
        
        _stairs.SetTrigger("trigger");
        
        


    }
}
