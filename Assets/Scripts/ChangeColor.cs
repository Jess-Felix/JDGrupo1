using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material[] colors;
    public float[] duration;
    private int i;
    private Renderer m;


    private void Start()
    {
        m = GetComponent<Renderer>();
        i = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (i >= colors.Length) 
        {
            i = 0;
        }
        
        if (duration[i] > 0)
        {
            m.material = colors[i];
            duration[i] -= Time.deltaTime;
            
        }
        else
        {
            duration[i] = 1.5f;
            i += 1;
        }
     


        



    }
}
