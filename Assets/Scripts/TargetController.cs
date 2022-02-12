using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    //Variables
    private float mouseX, mouseY;
    Vector2 rotation = Vector2.zero;
    public float mouseSensitivityX, mouseSensitivityY;

    //References
    private Transform parent;
    

    private void Start()
    {
        parent = transform.parent;
        
    }

    private void LateUpdate()
    {
        Rotate();
        
    }

    private void Rotate()
    {
        rotation.y += Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        rotation.x += Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        rotation.x = Mathf.Clamp(rotation.x, -20, 50);
        transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        parent.eulerAngles = new Vector2(0, rotation.y);
        
    }
}
