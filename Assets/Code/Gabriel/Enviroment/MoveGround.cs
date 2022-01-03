using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plataform, path;
    LineRenderer line;
    int lineSize;
    Vector3[] positionsFromLine;
    Vector3 oldDirection, actualDirection, linePosition, thisObjectPosition;
    void Start()
    {
        line = path.GetComponent<LineRenderer>();
        lineSize = line.positionCount;
        positionsFromLine = new Vector3[lineSize];
        for (int x = 0; x < lineSize; x++)
        {
            positionsFromLine[x] = line.GetPosition(x);
            Debug.Log(positionsFromLine[x]);
        }
        oldDirection = (positionsFromLine[1] - positionsFromLine[0]).normalized;
        linePosition = path.transform.position;
        thisObjectPosition = transform.position;
        plataform.transform.position = positionsFromLine[0] + thisObjectPosition + linePosition;
        contPlataform = 1;
        actualDirection = plataform.transform.position + Vector3.right;
        
    }

    // Update is called once per frame
    Vector3 direction;
    public float speed = 0.1f;
    int contPlataform = 0, directionPlataform = 1;
    void FixedUpdate()
    {
        direction = (positionsFromLine[contPlataform] + thisObjectPosition + linePosition - plataform.transform.position).normalized;
        //Debug.DrawRay(plataform.transform.position,direction,Color.magenta, 1);
        //Debug.Log(oldDirection + " " + direction);
        if (Vector3.Distance(positionsFromLine[contPlataform] + thisObjectPosition + linePosition, plataform.transform.position) > 0.01f)
        {
            actualDirection = plataform.transform.position;
            plataform.transform.Translate(direction * speed);           
        }
        else
        {
            Debug.DrawRay(plataform.transform.position, Vector3.up, Color.blue, 1);
            
            if(contPlataform == 0)
            {
                directionPlataform = 1;
            }
            else if (contPlataform == lineSize - 1)
            {
                directionPlataform = -1;
            }
            contPlataform = contPlataform + directionPlataform;
            //Debug.LogError("Mudou a Direção " + contPlataform);
            oldDirection = (positionsFromLine[contPlataform] - plataform.transform.position).normalized;
        }
    }
}
