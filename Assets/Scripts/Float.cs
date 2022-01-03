using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    // Start is called before the first frame update
    float originalY;
    public float degreesPerSecond = 15.0f;

    public float floatStrength = 1; // You can change this in the Unity Editor to 
                                    // change the range of y positions that are possible.

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Math.Sin(Time.time) * floatStrength),
            transform.position.z);

    }
}
