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

        for (int i = 0; i < loadColors.Length; i++)
        {
            colorsToLoad[i] = loadColors[i].name;
        }

        ground = LayerMask.NameToLayer("Ground");

        

        StartCoroutine("ColorChanger");
    }

    int colorCount = 0;

    IEnumerator ColorChanger()
    {
        while (true)
        {
            if (colorCount >= loadColors.Length)
            {
                colorCount = 0;
            }

            usingMaterial.material = loadColors[colorCount];
            colorPlataform.tag = colorsToLoad[colorCount];
            
            yield return new WaitForSeconds(2f);
            colorCount++;
        }
    }    
}
