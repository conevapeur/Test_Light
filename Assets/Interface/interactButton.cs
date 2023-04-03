using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactButton : MonoBehaviour, IInteract
{
    [SerializeField] private Animator _archives;
    [SerializeField] private GameObject _redLigths;

    private void Start()
    {
        
    }
    public void OnInteract()
    {
        _redLigths.gameObject.SetActive(true);
        LightmapSettings.lightmaps = new LightmapData[] { };
        _archives.SetTrigger("trigger");
    }
}
