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

        controls.actions.card.performed += ctx => animator.SetTrigger("triggerCard");  //    A    declenche le trigger de la carte          oui         fait
        controls.actions.read.performed += ctx => animator.SetTrigger("triggerRead");  //    Z    declenche le trigger des readables        oui         fait
        controls.actions.wakeup.performed += ctx => animator.SetTrigger("triggerWake");  //    E    se releve au respawn                    optionnel
        controls.actions.table.performed += ctx => animator.SetTrigger("triggerTable");  //    R    grimper table                           
        controls.actions.chair.performed += ctx => animator.SetTrigger("triggerChair");  //    T    grimper chaise                          oui
        controls.actions.secu.performed += ctx => animator.SetTrigger("triggerSecu");  //    Y    anim secu room // a voir avec Levi        
        controls.actions.stairs.performed += ctx => animator.SetTrigger("triggerStairs");  //    U    tomber des escaliers                  
        controls.actions.airduct.performed += ctx => animator.SetTrigger("triggerAirduct");  //    I    tomber de la vent


        controls.actions.talkie.performed += ctx => animator.SetTrigger("triggerTalkie");  //    Q    apparaitre le talkie POUR L'UTILISER      oui     fait
        controls.actions.talkieincrease.performed += ctx => animator.SetTrigger("triggerTalkie+");  //    S    + preset                         oui     fait
        controls.actions.talkiedecrease.performed += ctx => animator.SetTrigger("triggerTalkie-");  //    D    - preset                         oui     fait
        controls.actions.endtalkie.performed += ctx => animator.SetTrigger("triggerEndTalkie");  //    F    ranger le talkie POUR L'UTILISER    oui     fait


        controls.actions.talk.performed += ctx => animator.SetTrigger("triggerTalk");  //    J    apparaitre le talkie POUR PARLER              optionnel
        controls.actions.endtalk.performed += ctx => animator.SetTrigger("triggerEndTalk");  //    K    fin du talkie POUR PARLER               optionnel


        controls.actions.death.performed += ctx => animator.SetTrigger("triggerDeath");  //    SPACE    death                                   optionnel


        controls.actions.hand.performed += ctx => animator.SetTrigger("triggerHand");  //    B    mains devant les yeux                         oui
        controls.actions.endhand.performed += ctx => animator.SetTrigger("triggerEndHand");  //    N    enlever                                 oui
        


        controls.actions.grab.performed += ctx => animator.SetTrigger("triggerGrab");  //    W    Debut du grab                                 oui
        controls.actions.push.performed += ctx => animator.SetBool("boolPush", true);  //    X    bool "je pousse"                              oui
        controls.actions.push.canceled += ctx => animator.SetBool("boolPush", false);  //    X    arret de "je pousse"                          oui
        controls.actions.endpush.performed += ctx => animator.SetTrigger("triggerEndGrab");  //    C    lacher le grab                          oui

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
