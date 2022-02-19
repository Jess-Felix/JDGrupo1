using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSubtitle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject subtitle;
    public AudioSource narration;
    void Start()
    {
        narration = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!narration.isPlaying)
        {
            subtitle.SetActive(false);
        }
        
    }
}
