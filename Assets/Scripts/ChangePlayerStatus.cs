using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerStatus : MonoBehaviour
{
    //Access the object detection script to get tag reference
    public String objectTag;
    
    //Access Player materials
    public GameObject player;
    public Material[] m;

    //New Materials
    public Material red;
    public Material blue;
    public Material yellow;
    public Material white;


    private void Start()
    {
        m = player.GetComponent<SkinnedMeshRenderer>().materials;

    }

    // Update is called once per frame
    void Update()
    {
        if (objectTag == "Red")
        {
            m[0] = new Material(red);
            m = player.GetComponent<SkinnedMeshRenderer>().materials = m;
            //Debug.Log("Mudou Material");

        } else if (objectTag == "Blue")
        {
            //change light material to blue
            m[0] = new Material(blue);
            m = player.GetComponent<SkinnedMeshRenderer>().materials = m;
            
        } else if (objectTag == "Yellow")
        {
            //change light material to yellow
            m[0] = new Material(yellow);
            m = player.GetComponent<SkinnedMeshRenderer>().materials = m;
            
        } else if (objectTag == "White")
        {
            //change light material to yellow
            m[0] = new Material(white);
            m = player.GetComponent<SkinnedMeshRenderer>().materials = m;
            
        }
        
    }
}
