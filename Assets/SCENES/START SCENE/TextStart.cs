using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextStart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text startB;
    [SerializeField] TMP_Text creditsB;
    [SerializeField] TMP_Text settingsB;
    [SerializeField] TMP_Text quitB;

    [Space(10)]
    [SerializeField] TMP_Text credits;

    [Space(10)]
    [SerializeField] TMP_Text settings;

    [Space(10)]
    [SerializeField] TMP_Text controls;

    [Space(10)]
    [SerializeField] TMP_Text volume;
    [SerializeField] TMP_Text masterV;
    [SerializeField] TMP_Text SFXV;
    [SerializeField] TMP_Text DialoguesV;
    [Space(10)]

    [SerializeField] TMP_Text language;
    [SerializeField] TMP_Text english;
    [SerializeField] TMP_Text french;
    [SerializeField] TMP_Text subtitles;

    [Space(10)]
    [SerializeField] TMP_Text back1;
    //[SerializeField] TMP_Text back2;
    [SerializeField] TMP_Text back3;

    public void English()
    {
        startB.SetText("START");
        creditsB.SetText("CREDITS");
        settingsB.SetText("SETTINGS");
        quitB.SetText("QUIT");
        credits.SetText("LES CREDITS ICI EN ANGLAIS");
        back1.SetText("BACK");
        //back2.SetText("BACK");
        back3.SetText("BACK");
        volume.SetText("VOLUME");
        controls.SetText("CONTROLS");
        language.SetText("LANGUAGE");
        masterV.SetText("MASTER VOLUME");
        SFXV.SetText("SFX VOLUME");
        DialoguesV.SetText("DIALOGUES VOLUME");
        english.SetText("ENGLISH");
        french.SetText("FRANCAIS");
        subtitles.SetText("SUBTITLES");
        settings.SetText("SETTINGS");
    }

    public void French()
    {
        startB.SetText("JOUER");
        creditsB.SetText("CREDITS");
        settingsB.SetText("REGLAGES");
        quitB.SetText("QUITTER");
        credits.SetText("LES CREDITS ICI");
        back1.SetText("RETOUR");
        //back2.SetText("RETOUR");
        back3.SetText("RETOUR");
        volume.SetText("VOLUME");
        controls.SetText("CONTROLES");
        language.SetText("LANGAGE");
        masterV.SetText("VOLUME PRINCIPAL");
        SFXV.SetText("VOLUME SFX");
        DialoguesV.SetText("VOLUME DIALOGUES");
        english.SetText("ENGLISH");
        french.SetText("FRANCAIS");
        subtitles.SetText("SOUS-TITRES");
        settings.SetText("REGLAGES");
    }
}
