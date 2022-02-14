using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GroundDetectionv2 : MonoBehaviour
{

    string tagName = "";

    public ObjDetection2 playerColorHolder;
    
    private LayerMask ground;

    public GameOverFade bool_gameOver;
    private void Start()
    {
        ground = LayerMask.NameToLayer("Ground");
    }

    [SerializeField] public GameObject keyRed, keyBlue, keyWhite, keyYellow;

    private void OnTriggerStay(Collider other)
    {
        tagName = other.gameObject.tag;
        if (ground == other.gameObject.layer)
        {
            if (playerColorHolder.currentColor != "" && tagName != "Gray")
            {
                Debug.Log("Ground Tag " + tagName + " cubeColor -> " + playerColorHolder.currentColor);
                if (tagName != playerColorHolder.currentColor) //reseta o cenario se pisar errado
                {
                    //SceneManager.LoadScene(currentSceneName);
                    bool_gameOver.gameOver = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        tagName = other.gameObject.tag;
        if (ground == other.gameObject.layer)
        {
            if (playerColorHolder.currentColor != "" && tagName != "Gray")
            {
                Debug.Log("Ground Tag " + tagName + " cubeColor -> " + playerColorHolder.currentColor);
                if (tagName != playerColorHolder.currentColor)//reseta o cenario se pisar errado
                {
                    //SceneManager.LoadScene(currentSceneName);
                    bool_gameOver.gameOver = true;
                }
            }
        }
    }
    
}
