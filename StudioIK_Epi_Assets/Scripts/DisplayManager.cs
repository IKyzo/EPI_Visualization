using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager
{
    /* 
     Input System : 
        Right Arrow => Move to the object on the Right // 1 
        Left Arrow => Move to the object on the Left // -1
        
            
    
     */

    public void InputDisplay(int inputValue)
    {
		switch (inputValue)
		{
            case 1:

                break;
            case -1:

                break;
            default:
                Debug.Log("Invalid input - Display Manager");
				break;
		}
	}

}
