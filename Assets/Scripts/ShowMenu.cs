using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ShowMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    



    private void Start()
    {
        videoPlayer.loopPointReached += CheckOver;
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print  ("Video Is Over");
        LoadB(2);

    }
    
    public void LoadB(int sceneNumber)
    {

        SceneManager.LoadScene(sceneNumber);
    }

 
}

