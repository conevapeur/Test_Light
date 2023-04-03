using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactCard: MonoBehaviour, IInteract
{
    [SerializeField] private Animator _security;

    public void OnInteract()
    {
        _security.SetTrigger("trigger");
    }
}
