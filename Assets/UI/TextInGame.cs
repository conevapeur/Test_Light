using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInGame : MonoBehaviour
{
    [SerializeField] TMP_Text quit;
    [SerializeField] TMP_Text yesquit;
    [SerializeField] TMP_Text noquit;
    [SerializeField] TMP_Text quitquestion;

    [SerializeField] TMP_Text resume;
    [SerializeField] TMP_Text pause;

    [SerializeField] TMP_Text options;
    [SerializeField] TMP_Text settings;
    [SerializeField] TMP_Text volume;
    [SerializeField] TMP_Text volume1;
    [SerializeField] TMP_Text volume2;
    [SerializeField] TMP_Text volume3;
    [SerializeField] TMP_Text controls;
    [SerializeField] TMP_Text language;
    [SerializeField] TMP_Text english;
    [SerializeField] TMP_Text french;
    [SerializeField] TMP_Text subtitles;

    [SerializeField] TMP_Text title;
    private void Awake()
    {
        if (!UIStart.ENG && !UIStart.FR)
        {
            UIStart.ENG = true;
        }

        
        
    }

    public void English()
    {
        quit.SetText("QUIT");
        yesquit.SetText("YES");
        noquit.SetText("NO");
        quitquestion.SetText("RETURN TO MAIN MENU");
        resume.SetText("RESUME");
        pause.SetText("PAUSE");
        options.SetText("SETTINGS");
        settings.SetText("SETTINGS");
        volume.SetText("VOLUME");
        volume1.SetText("MASTER VOLUME");
        volume2.SetText("SFX VOLUME");
        volume3.SetText("DIALOGUES VOLUME");
        controls.SetText("CONTROLS");
        language.SetText("LANGUAGE");
        english.SetText("ENGLISH");
        french.SetText("FRANCAIS");
        subtitles.SetText("SUBTITLES");
    }
    public void French()
    {
        quit.SetText("QUITTER");
        yesquit.SetText("OUI");
        noquit.SetText("NON");
        quitquestion.SetText("RETOURNER AU MENU PRINCIPAL");
        resume.SetText("CONTINUER");
        pause.SetText("PAUSE");
        options.SetText("REGLAGES");
        settings.SetText("REGLAGES");
        volume.SetText("VOLUME");
        volume1.SetText("VOLUME PRINCIPAL");
        volume2.SetText("VOLUME SFX");
        volume3.SetText("VOLUME DIALOGUES");
        controls.SetText("CONTROLES");
        language.SetText("LANGAGE");
        english.SetText("ENGLISH");
        french.SetText("FRANCAIS");
        subtitles.SetText("SOUS TITRES");
    }

}
