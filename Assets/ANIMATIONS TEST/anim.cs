using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{

    private TestANIM controls;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new TestANIM();

        controls.actions.card.performed += ctx => animator.SetTrigger("triggerCard");  //    A    declenche le trigger de la carte
        controls.actions.read.performed += ctx => animator.SetTrigger("triggerRead");  //    Z    declenche le trigger des readables
        controls.actions.wakeup.performed += ctx => animator.SetTrigger("triggerWake");  //    E    se releve au respawn
        controls.actions.table.performed += ctx => animator.SetTrigger("triggerTable");  //    R    grimper table
        controls.actions.chair.performed += ctx => animator.SetTrigger("triggerChair");  //    T    grimper chaise
        controls.actions.secu.performed += ctx => animator.SetTrigger("triggerSecu");  //    Y    anim secu room // a voir avec Levi 
        controls.actions.stairs.performed += ctx => animator.SetTrigger("triggerStairs");  //    U    tomber des escaliers 
        controls.actions.airduct.performed += ctx => animator.SetTrigger("triggerAirduct");  //    I    tomber de la vent


        controls.actions.talkie.performed += ctx => animator.SetTrigger("triggerTalkie");  //    Q    apparaitre le talkie POUR L'UTILISER
        controls.actions.talkieincrease.performed += ctx => animator.SetTrigger("triggerTalkie+");  //    S    + preset
        controls.actions.talkiedecrease.performed += ctx => animator.SetTrigger("triggerTalkie-");  //    D    - preset
        controls.actions.endtalkie.performed += ctx => animator.SetTrigger("triggerEndTalkie");  //    F    ranger le talkie POUR L'UTILISER


        controls.actions.talk.performed += ctx => animator.SetTrigger("triggerTalk");  //    J    apparaitre le talkie POUR PARLER
        controls.actions.endtalk.performed += ctx => animator.SetTrigger("triggerEndTalk");  //    K    fin du talkie POUR PARLER



        controls.actions.grab.performed += ctx => animator.SetTrigger("triggerGrab");  //    W    Debut du grab
        controls.actions.push.performed += ctx => animator.SetBool("boolPush", true);  //    X    bool "je pousse"
        controls.actions.push.canceled += ctx => animator.SetBool("boolPush", false);  //    X    arret de "je pousse"
        controls.actions.endpush.performed += ctx => animator.SetTrigger("triggerEndGrab");  //    C    lacher le grab

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        controls.actions.Enable();
    }
    private void OnDisable()
    {
        controls.actions.Disable();
    }
}
