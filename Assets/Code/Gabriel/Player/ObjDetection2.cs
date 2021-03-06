using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class ObjDetection2 : MonoBehaviour
{
    [SerializeField] public string currentColor = "White";

    private bool interact = false;
    
    public GameObject keyObject;
    public ChangePlayerStatus stringObjectTag ;
    
    public AudioSource audioClip;
    

    private void OnCollisionEnter(Collision collision) {
        LayerMask layerID;
        layerID = collision.gameObject.layer;
        
        //Get tag from object

        if (LayerMask.LayerToName(layerID) == "Hold")
        {     
            //Get tag from object
            keyObject = collision.gameObject;
            stringObjectTag.objectTag = keyObject.tag;
            
            // Update the current holding color
            currentColor = keyObject.tag;

            //play robot happy sound
            audioClip.GetComponent<AudioSource>();
            audioClip.Play();

            Debug.Log("Pegou o " + stringObjectTag);

            collision.collider.isTrigger = true;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            
            interact = true;
            
        }
    }

    public string GetCurrentColor() {
        return currentColor;
    }


    private float interactionTime;
    private bool holdingKey = false;
    private void Update()
    {
     /*   interactionTime = interactionTime + Time.deltaTime;
        if (interact == true && interactionTime > 0.4f)
        {
            if (keyObject.GetComponent<Respaw2>().canPick == true)
            {
                if (holdingKey == false)
                {
                    if (keyObject.layer == LayerMask.NameToLayer("Button"))
                    {
                        Debug.Log(keyObject.name);
                    }

                    //Debug.Log(keyObject.layer + " " + (Vector3.Distance(keyObject.transform.position, transform.position)));
                    //Debug.DrawLine(keyObject.transform.position, transform.position, Color.black, 4);

                    if (keyObject.layer == LayerMask.NameToLayer("Hold"))
                    {
                        //Debug.Log(keyObject.name);
                        GrabIt(keyObject);
                    }
                    holdingKey = true;
                    interactionTime = 0;
                }
                else
                {
                    //Debug.Log("Ja esta segurando algum objeto");
                }
            }
        }
        interact = false;
        */
    }

    //======
    // Start is called before the first frame update
    bool holdingAnyObject = false;
    GameObject objectHolder, oldObject;
    [SerializeField] private GameObject groundDetection;
    public void GrabIt(GameObject anotherObject)
    {
        //Debug.Log(objectHolder + " == " + oldObject);
        if (holdingAnyObject == false)
        {
            holdingAnyObject = true;
            objectHolder = anotherObject;
            groundDetection.SendMessage("CubeColor", anotherObject.tag);
        }
    }


    public void DropItColor(string _colorDrop)
    {
        currentColor = "White";
    }


    Rigidbody rbGrab;
    public void DropIt(Vector3 dropPoint)
    {
        Debug.Log(holdingAnyObject);
        Debug.DrawLine(transform.position, dropPoint, Color.red, 4);
        if (holdingAnyObject == true)
        {
            rbGrab.constraints = RigidbodyConstraints.None;
            rbGrab.useGravity = true;
            holdingAnyObject = false;

            oldObject = objectHolder;

            //Debug.DrawRay(dropPoint, Vector3.up, Color.red, 3);
        }
    }
}
