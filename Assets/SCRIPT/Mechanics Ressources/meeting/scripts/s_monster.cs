using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class s_monster : MonoBehaviour
{
    public bool isLooking;
    public GameObject player;
    public GameObject talkie;

    public int curFreq;
    public int playerFreq;

    [SerializeField] TMP_Text soustitres;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
        talkie = GameManager.instance.talkie;

        curFreq = talkie.GetComponent<talkie>().curFreq;

        playerFreq = talkie.GetComponent<talkie>().state;

        
    }

    // Update is called once per frame
    void Update()
    {


        if(isLooking)
        {
            
            if (player.GetComponent<FPC>().isCrouching == false )
            {
                GameManager.instance.Die();

                //soustitres.SetText("vous devriez etre mort");
            }
            else
            {

                //checkFreq();
                Debug.Log("en sécurité");

            }
        }
        
    }

    public void Inspection()
    {
        
    }

    private void look()
    {

    }

    /*private void checkFreq()
    {
        setFreq();
        if(curFreq == 0 && (playerFreq == 1 || playerFreq == 4))
        {
            player.GetComponent<FPC>().Die();
            soustitres.SetText("vous devriez etre mort");
        }
        else if (curFreq == 4 && (playerFreq == 0 || playerFreq == 3))
        {
            soustitres.SetText("vous devriez etre mort");
            player.GetComponent<FPC>().Die();
        }
        else if (Mathf.Abs(playerFreq - curFreq) <= 1)
        {
            player.GetComponent<FPC>().Die();
            soustitres.SetText("vous devriez etre mort");
        }
        else
        {
            Debug.Log("vous survivez");
            soustitres.SetText("en sécurité");
        }
    }*/

    private void setFreq()
    {
        curFreq = talkie.GetComponent<talkie>().curFreq;

        playerFreq = talkie.GetComponent<talkie>().state;
    }

    
}
