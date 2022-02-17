using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    //Visual and audio feedback from winning condition
    public float fadeDuration = 1f;
    public CanvasGroup gameWinFade;
    float m_Timer;
    public float displayImageDuration = 0.5f;
    public AudioSource gameWinAudio;
    private bool m_HasAudioPlayed;

    private bool HasWin;
    
    public bool keyBlack = true, keyBlue = false, keyRed = false, keyYellow = false, keyWhite = false;
    public void KeyImput(string keyName)
    {
        switch(keyName)
        {

            case "Blue":
                {
                    keyBlue = true;
                    break;
                }
            case "Red":
                {
                    keyRed = true;
                    break;
                }
            case "Yellow":
                {
                    keyYellow = true;
                    break;
                }
            case "White":
                {
                    keyWhite = true;
                    break;
                }
        }
        if (keyBlue == true && keyRed == true && keyYellow == true && keyWhite == true)
        {
            HasWin = true;
        }
    }

    public void Update()
    {

        if (HasWin)
        {
            WinCondition();
        }
    }

    // Update is called once per frame
    public void WinCondition()
    {        
        if (!m_HasAudioPlayed)
        {
            gameWinAudio.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        gameWinFade.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            //Debug.Log("quit");
            Application.Quit ();
        }
    }

    public void FullReset()
    {
        keyBlack = true;
        keyBlue = false;
        keyRed = false;
        keyYellow = false;
        keyWhite = false;
    }
}
