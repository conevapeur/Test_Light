using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;

using UnityEngine.Rendering;

public class TextEnd : MonoBehaviour
{
    [SerializeField] TMP_Text credits;
    [SerializeField] TMP_Text skip;

    private void Awake()
    {
        if (!UIStart.ENG && !UIStart.FR)
        {
            UIStart.ENG = true;
        }

        if (!UIStart.ENG)
        {
            credits.SetText("credits en anglais");
            skip.SetText("SKIP");
        }
        else
        {
            credits.SetText("credits en francais");
            skip.SetText("PASSER");
        }
    }
    
}
