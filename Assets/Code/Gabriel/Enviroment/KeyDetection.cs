using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetection : MonoBehaviour
{
    Ray raio;
    RaycastHit ponto;
    Vector3 spawPosition;
    private void Start()
    {
        if(Physics.Raycast(transform.position + Vector3.up,Vector3.down,out ponto))
        {
            spawPosition = ponto.point;
            //Debug.Log(ponto.collider.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider collision)
    //private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            transform.parent.SendMessage("KeyImput", gameObject.tag);
            collision.gameObject.SendMessage("HoldStatus");
            collision.gameObject.SendMessage("DropItColor", gameObject.tag);
            collision.gameObject.SendMessage("DropIt", spawPosition);
        }
        else if(collision.transform.gameObject.layer == LayerMask.NameToLayer("Hold"))
        {
            collision.gameObject.SendMessage("PickStarts", false);
        }
        /*
        else if(collision.gameObject.tag != "Untagged")
        {
            transform.parent.SendMessage("FullReset", gameObject.tag);            
        }
        */
    }
}
