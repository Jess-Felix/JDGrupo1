using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject _instance;
    // Start is called before the first frame update
    void Awake ()
    {
        if (DontDestroy._instance )
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);   
        }
        
    }

  
}
