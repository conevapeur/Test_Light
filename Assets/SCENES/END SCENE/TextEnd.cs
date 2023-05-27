using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;

using UnityEngine.Rendering;

public class TextEnd : MonoBehaviour
{
    //[SerializeField] TMP_Text credits;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject gotext;

    [SerializeField] TMP_Text skip;
    

    private void Awake()
    {
        
        if (UIStart.SUB)
        {
            gotext.SetActive(true);
        }
        else
        {
            gotext.SetActive(false);
        }

        if (UIStart.ENG)
        {
            //credits.SetText("Remerciements (mais en anglais)");
            skip.SetText("SKIP");
            
        }
        else
        {
            //credits.SetText("Remerciements");
            skip.SetText("PASSER");
        }

        
    }


    public void Text1()
    {
        if (UIStart.ENG)
        {
            text.SetText("Dad! Help, come help me please!!");

        }
        else
        {
            text.SetText("Papa! à l'aide, viens m'aider!!");
        }
    }

    public void Text2()
    {
        if (UIStart.ENG)
        {
            text.SetText("I'm coming Amy");
        }
        else
        {
            text.SetText("J'arrive Amy!");
        }
    }
    
}
