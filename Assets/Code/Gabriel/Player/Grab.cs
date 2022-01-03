using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public GameObject grabGameObject;//gameObject que armazena a posição do objeto que esta sendo segurado
    // Start is called before the first frame update
    bool holdingAnyObject = false;
    GameObject objectHolder, oldObject;
    public void GrabIt(GameObject anotherObject)
    {
        Debug.Log(objectHolder+" == "+oldObject);
        if (holdingAnyObject == false)
        {
            rbGrab = anotherObject.GetComponent<Rigidbody>();
            rbGrab.useGravity = false;
            rbGrab.constraints = RigidbodyConstraints.FreezeAll;
            anotherObject.transform.parent = grabGameObject.transform;
            anotherObject.transform.localPosition = Vector3.zero;
            
           holdingAnyObject = true;
            objectHolder = anotherObject;
        }
    }

    Rigidbody rbGrab;
    public void DropIt(Vector3 dropPoint)
    {
        if (holdingAnyObject == true)
        {
            rbGrab.constraints = RigidbodyConstraints.None;
            rbGrab.useGravity = true;
            holdingAnyObject = false;
            
            oldObject = objectHolder;
            grabGameObject.transform.position = new Vector3(dropPoint.x, dropPoint.y + 0.5f, dropPoint.z);
            grabGameObject.transform.DetachChildren();
            Debug.DrawRay(dropPoint, Vector3.up, Color.red, 3);
        }
    }

    public void DropAndRespaw()
    {
        if (holdingAnyObject == true)
        {
            holdingAnyObject = false;
            grabGameObject.transform.DetachChildren();
            oldObject = objectHolder;
            objectHolder.SendMessage("Respaw_");
        }
    }
}
