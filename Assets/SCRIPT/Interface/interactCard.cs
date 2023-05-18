using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactCard: MonoBehaviour, IInteract
{
    [SerializeField] private Animator _security;
    [SerializeField] private Animator animatorCam;

    private void Awake()
    {
        interactReadable.card = true;
    }
    public void OnInteract()
    {
        Debug.Log(interactReadable.card);


        if (interactReadable.card == true)
        {
            StartCoroutine(cardCoroutine());
        }

        IEnumerator cardCoroutine()
        {
            
            GameManager.instance.player.GetComponent<FPC>().animator.SetTrigger("triggerCard");
            animatorCam.SetTrigger("triggerCard");
            interactReadable.card = false;
            yield return new WaitForSeconds(2f);
            _security.SetTrigger("trigger");
            

        }

    }
}
