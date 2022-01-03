using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChanger : MonoBehaviour
{
    public Material[] loadColors;
    MeshRenderer usingMaterial;
    public GameObject colorPlataform;
    string[] colorsToLoad = new string[5];
    LayerMask ground;
    public bool usingBlack = true, usingBlue = true, usingYellow = true, usingRed = true, usingWhite = true;
    // Start is called before the first frame update
    int[] arrayColors;
    List<int> listColors;
    void Start()
    {
        usingMaterial = colorPlataform.GetComponent<MeshRenderer>();
        listColors = new List<int>();
        colorsToLoad[0] = "Red";
        colorsToLoad[1] = "Blue";
        colorsToLoad[2] = "Yellow";
        colorsToLoad[3] = "Black";
        colorsToLoad[4] = "White";
        ground = LayerMask.NameToLayer("Ground");
        if (usingRed == true)
        {
            listColors.Add(0);
        }        
        if (usingBlue == true)
        {
            listColors.Add(1);
        }
        if (usingYellow == true)
        {
            listColors.Add(2);
        }
        if (usingBlack == true)
        {
            listColors.Add(3);
        }
        if (usingWhite == true)
        {
            listColors.Add(4);
        }
        arrayColors = listColors.ToArray();
        StartCoroutine("ColorChanger");
    }

    int colorCount = 0;
    IEnumerator ColorChanger()
    {
        while (true)
        {
            if(colorCount < arrayColors.Length)
            {
                usingMaterial.material = loadColors[colorCount];
                colorPlataform.tag = colorsToLoad[colorCount];
            }
            else
            {
                colorCount = 0;
                usingMaterial.material = loadColors[colorCount];
                colorPlataform.tag = colorsToLoad[colorCount];
            }
            yield return new WaitForSeconds(3);
            colorCount++;
        }
    }    
}
