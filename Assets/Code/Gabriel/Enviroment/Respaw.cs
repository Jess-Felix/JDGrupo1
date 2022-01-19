using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respaw : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 oldPosition;
    public bool canPick = true;

    void Start()
    {
        oldPosition = transform.position;
    }

    public void Respaw_()
    {
        Debug.Log("Respaw");
        transform.position = oldPosition;
        canPick = true;
    }

    public void PickStarts(bool status)
    {
        canPick = status;
    }
}
