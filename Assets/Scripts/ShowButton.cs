using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ShowButton : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject button;

    private void Start()
    {
        videoPlayer.loopPointReached += CheckOver;
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print  ("Video Is Over");
        button.SetActive(true);
    }
 
}

