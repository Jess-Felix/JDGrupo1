using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class KeyDetection2 : MonoBehaviour {
    // Variable to access current Light Beam tag
    

    private void OnTriggerEnter(Collider collision)
    {
        GameObject player = collision.transform.gameObject;
        if (!player.CompareTag("Player")) return;
        
        String status = player.GetComponent<ChangePlayerStatus>().objectTag;
        
        //Debug.LogError(collision.gameObject.name);
        if (player.layer == LayerMask.NameToLayer("Player") && transform.gameObject.tag == status )
        {
            Debug.Log("Delivered collectible " + gameObject.tag);
            transform.parent.SendMessage("KeyImput", gameObject.tag);
            //collision.gameObject.SendMessage("HoldStatus");
            collision.gameObject.SendMessage("DropItColor", gameObject.tag);
        }
        else if(collision.transform.gameObject.layer == LayerMask.NameToLayer("Hold"))
        {
            collision.gameObject.SendMessage("PickStatus", false);
        }
    }
}
