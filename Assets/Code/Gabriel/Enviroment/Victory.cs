using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    bool keyBlue = false, keyRed = false, keyYellow = false, keyWhite = false;
    public void KeyImput(string keyName)
    {
        switch(keyName)
        {

            case "Blue":
                {
                    keyBlue = true;
                    break;
                }
            case "Red":
                {
                    keyRed = true;
                    break;
                }
            case "Yellow":
                {
                    keyYellow = true;
                    break;
                }
            case "White":
                {
                    keyWhite = true;
                    break;
                }
        }
        if (keyBlue == true && keyRed == true && keyYellow == true && keyWhite == true)
        {
            WinCondition();
        }
    }
    // Update is called once per frame
    public void WinCondition()
    {        
        Debug.Log("Vitoria de nivel");
    }

    public void FullReset()
    {
//
        keyBlue = false;
        keyRed = false;
        keyYellow = false;
        keyWhite = false;
    }
}
