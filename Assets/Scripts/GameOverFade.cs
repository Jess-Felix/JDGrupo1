using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFade : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float fadeDuration = 1f;
    public bool gameOver = false;
    public CanvasGroup gameOverFade;
    float m_Timer;
    public float displayImageDuration = 0.5f;
    
    private string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        gameOverFade.alpha = m_Timer / fadeDuration;
        
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            Debug.Log("reload scene");
            SceneManager.LoadScene(currentSceneName);
            //Application.Quit ();
        }
        
    }
}
