using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class BABAR : MonoBehaviour
{
    [System.Serializable]
   public class KeyState
   {

        public KeyScenario key;
        public bool state = false;


   }



    [SerializeField]
    public KeyScenario DebugGetKey;

    [SerializeField]
    public List<KeyState> keys;

    private void Start()
    {
        InitializeKeys();
    }
    public void InitializeKeys() // remettre les keys a 0
    {

        foreach (KeyState _key in keys)
        {
            _key.state = false;
        }
    }

    public void getKey()
    {
       
    }

    public void changeKeyState()
    {
        
    }


    public bool? GetStateOfKey(KeyScenario _key)
    {
        
        return keys.SingleOrDefault(t => t.key == _key)?.state;

    }


    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(GetStateOfKey(DebugGetKey));

        }

    }

}
