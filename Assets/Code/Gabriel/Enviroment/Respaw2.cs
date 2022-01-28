using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respaw2 : MonoBehaviour
{
    public bool canPick = true;

    public void Respaw_()
    {
        Debug.Log("Respaw");
        canPick = true;
    }

    public void PickStatus(bool status)
    {
        canPick = status;
    }
}
