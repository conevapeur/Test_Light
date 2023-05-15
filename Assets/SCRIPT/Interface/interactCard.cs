using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactCard: MonoBehaviour, IInteract
{
    [SerializeField] private Animator _security;

    public void OnInteract()
    {
        Debug.Log(interactReadable.card);
        if (interactReadable.card == true)
        {
            _security.SetTrigger("trigger");
            GameManager.instance.player.GetComponent<FPC>().animator.SetTrigger("triggerCard");
        }

    }
}
