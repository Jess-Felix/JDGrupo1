using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    string tagName = "";
    LayerMask ground;
    Vector3 startPosition;
    private void Start()
    {
        ground = LayerMask.NameToLayer("Ground");
        startPosition = transform.parent.transform.position;
        cubeColor = "White";
    }
    public GameObject keyBlack, keyRed, keyBlue, keyWhite, keyYellow;
    private void OnTriggerEnter(Collider other)
    {
        tagName = other.gameObject.tag;
        if (ground == other.gameObject.layer)
        {
            if (cubeColor != "" && tagName != "Gray")
            {
                Debug.Log("Ground Tag " + tagName + " cubeColor -> " + cubeColor);
                if (tagName != cubeColor)
                {
                    Debug.Log("Reseta");
                    cubeColor = "White";
                    transform.parent.SendMessage("DropAndRespaw");

                    keyBlack.SendMessage("Respaw_");
                    keyRed.SendMessage("Respaw_");
                    keyBlue.SendMessage("Respaw_");
                    keyWhite.SendMessage("Respaw_");
                    keyYellow.SendMessage("Respaw_");

                    keyBlack.layer = LayerMask.NameToLayer("Hold");
                    keyRed.layer = LayerMask.NameToLayer("Hold");
                    keyBlue.layer = LayerMask.NameToLayer("Hold");
                    keyWhite.layer = LayerMask.NameToLayer("Hold");
                    keyYellow.layer = LayerMask.NameToLayer("Hold");

                    transform.parent.transform.position = startPosition;
                    transform.parent.gameObject.SendMessage("HoldStatus");
                }
            }
        }
    }

    public string cubeColor = "White";
    public void CubeColor(string _cubeColor)
    {
        cubeColor = _cubeColor;
    }
}
