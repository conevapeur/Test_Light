using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactButton : MonoBehaviour, IInteract
{
    [SerializeField] private Animator _archives;
    [SerializeField] private Animator _open;
    [SerializeField] private Animator _bureau2;
    [SerializeField] private GameObject _redLigths;

    private void Start()
    {
        _redLigths.gameObject.SetActive(false);
    }
    public void OnInteract()
    {
        _redLigths.gameObject.SetActive(true);
        LightmapSettings.lightmaps = new LightmapData[] { };
        _archives.SetTrigger("trigger");
        //_open.SetTrigger("trigger");
        _bureau2.SetTrigger("trigger");        
    }
}
