using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjDetection : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = transform.parent.gameObject;
        Debug.Log(player.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        LayerMask layerID;
        layerID = other.gameObject.layer;        
        if(LayerMask.LayerToName(layerID) == "Hold")
        {
            player.SendMessage("ObjectDetection", other.gameObject);
        }
    }
}
