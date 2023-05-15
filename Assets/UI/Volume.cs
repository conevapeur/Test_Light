using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    private UI uicontrols;
    
   


    int score = 0;
    int left = 0;
    int right = 0;
    

    void Awake()
    {
       
        uicontrols = new UI();

        uicontrols.Menu.left.performed += ctx => Left();
        uicontrols.Menu.left.canceled += ctx => StopLeft();

        uicontrols.Menu.right.performed += ctx => Right();
        uicontrols.Menu.right.canceled += ctx => StopRight();
    }

    void FixedUpdate()
    {

        Debug.Log(score);
        if(right == 1)
        {
            score += 1;
        }
        if (left == 1)
        {
            score -= 1;
        }

    }

    
    void StopLeft()
    {
        left = 0;
        
    }

    void StopRight()
    {
        right = 0;
       
    }

    void Left()
    {  
        left = 1;  
    }
    void Right()
    {
        right = 1;
    }

    

    private void OnEnable()
    {
        uicontrols.Menu.Enable();
    }
    private void OnDisable()
    {
        uicontrols.Menu.Disable();
    }
}
