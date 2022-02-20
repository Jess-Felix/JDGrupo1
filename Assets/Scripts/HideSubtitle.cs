using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSubtitle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject subtitle;


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            subtitle.SetActive(false);
        }
        
    }
}
