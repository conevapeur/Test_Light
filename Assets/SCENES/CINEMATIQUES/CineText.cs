using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CineText : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    private void Awake()
    {
        if (!UIStart.ENG && !UIStart.FR)
        {
            UIStart.ENG = true;
        }
    }
    public void Text1()
    {
        if (UIStart.ENG)
        {
            text.SetText("Amy, if something goes wrong with the aftermath of the earthquake of last night, use the talkie canal 1. Your father who loves you.");
        }
        else
        {
            text.SetText("Amy, Après les évènements de cette nuit, si tu as un problème, je suis joignable sur le talkie, canal 1. Signé : ton papa qui t’aime.");
        }
    }

    public void Text2()
    {
        if (UIStart.ENG)
        {
            text.SetText("Amy, Amy! Are you there? Can you hear me? I need you to meet me on the forest path. Join me, I'll explain when you get there.");
        }
        else
        {
            text.SetText("Amy, Amy! Tu es là? Tu m'entends? Amy? J'ai besoin que tu me retrouves sur le chemin de la forêt. Rejoins-moi je t'explique quand on se retrouve.");
        }
    }

    public void Text3()
    {
        if (UIStart.ENG)
        {
            text.SetText("Dad, I'm here. What's going on?.");
        }
        else
        {
            text.SetText("Papa je suis là, qu'est ce qu'il se passe?");
        }
    }

    public void Text4()
    {
        if (UIStart.ENG)
        {
            text.SetText("Nothing's happening, don't worry. I just need you to see that");
        }
        else
        {
            text.SetText("Rien de grave, ne t'inquiètes pas. Il faut que tu vois ça!");
        }
    }

    public void Text5()
    {
        if (UIStart.ENG)
        {
            text.SetText("You're sure Dad? You always tell me not to go out of the house on my own");
        }
        else
        {
            text.SetText("T'es sûr papa? Tu me dis toujours de pas sortir de la maison toute seule!");
        }
    }

    public void Text6()
    {
        if (UIStart.ENG)
        {
            text.SetText("Yes, you know the path, you're all grown up now, come meet me there");
        }
        else
        {
            text.SetText("Oui, tu connais le chemin, tu es grande maintenant, rejoins moi.");
        }
    }

    public void Text7()
    {
        if (UIStart.ENG)
        {
            text.SetText("Okay dad, I'm coming.");
        }
        else
        {
            text.SetText("Ok papa, j'arrive.");
        }
    }

    public void Text8()
    {
        if (UIStart.ENG)
        {
            text.SetText("Aaaaaah");
        }
        else
        {
            text.SetText("Aaaaaah");
        }
    }




}
