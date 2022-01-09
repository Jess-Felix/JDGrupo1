using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == gameObject.tag)
        {
            transform.parent.SendMessage("KeyImput", gameObject.tag);
        }
        else if(collision.gameObject.tag != "Untagged")
        {
            transform.parent.SendMessage("FullReset", gameObject.tag);            
        }
    }
}
