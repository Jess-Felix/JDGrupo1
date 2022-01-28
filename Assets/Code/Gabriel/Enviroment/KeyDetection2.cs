using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetection2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    //private void OnCollisionEnter(Collision collision)
    {
        //Debug.LogError(collision.gameObject.name);
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
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
