using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GroundDetectionv2 : MonoBehaviour
{
    string tagName = "";
    private LayerMask ground;
    private Vector3 startPosition;
    private string currentSceneName;

    public GameOverFade bool_gameOver;
    private void Start()
    {
        ground = LayerMask.NameToLayer("Ground");
        startPosition = transform.parent.transform.position;
        cubeColor = "White";
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    [SerializeField] public GameObject keyRed, keyBlue, keyWhite, keyYellow;
    private void OnTriggerEnter(Collider other)
    {
        tagName = other.gameObject.tag;
        if (ground == other.gameObject.layer)
        {
            if (cubeColor != "" && tagName != "Gray")
            {
                Debug.Log("Ground Tag " + tagName + " cubeColor -> " + cubeColor);
                if (tagName != cubeColor)//reseta o cenario se pisar errado
                {
                    //SceneManager.LoadScene(currentSceneName);
                    bool_gameOver.gameOver = true;
                }
            }
        }
    }

    [SerializeField] public string cubeColor = "White";
    public void CubeColor(string _cubeColor)
    {
        cubeColor = _cubeColor;
    }
}
