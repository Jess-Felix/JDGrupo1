using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion playerRotation;
    float fowardAnim = 0, rightAnim = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fpsCam = _Camera.GetComponentInParent<Camera>();
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            rb.freezeRotation = true;        
    }

    float timeFlow,interactionTime;
    Vector3 directions;
    private void FixedUpdate()
    {
        timeFlow = Time.deltaTime;
        playerPosition = Player_.transform.position;
        playerRotation = Player_.transform.rotation;
        PlayerMove();
        PlayerMouse();
        interactionTime = interactionTime + timeFlow;
    }


    Vector3 playerPosition;
    public GameObject Player_,groundDetection;
    string lastKey, recordedLastKey;
    float timeHoldingKey = 0;
    Quaternion recprdedCemeRotation;
    public float speed;
    public Animator AnimeRobot;
    bool MoveKey = false, interact = false, jump = false;
    Ray raio;
    RaycastHit hit;
    Camera fpsCam;
    void PlayerMove()
    {
        //fowardAnim, rightAnim;
       
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.E))
            {
                interact = true;
                Debug.Log("Apertou E");
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    lastKey = "AW";
                    MoveKey = true;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    lastKey = "DW";
                    MoveKey = true;
                }
                else
                {
                    lastKey = "W";
                    MoveKey = true;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    lastKey = "SA";
                    MoveKey = true;
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    lastKey = "AW";
                    MoveKey = true;
                }
                else
                {
                    lastKey = "A";
                    MoveKey = true;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    lastKey = "SA";
                    MoveKey = true;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    lastKey = "DS";
                    MoveKey = true;
                }
                else
                {
                    lastKey = "S";
                    MoveKey = true;

                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    lastKey = "DS";
                    MoveKey = true;
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    lastKey = "DW";
                    MoveKey = true;
                }
                else
                {
                    lastKey = "D";
                    MoveKey = true;
                }
            }
        }
        else
        {
            lastKey = "No Key";

        }
        timeHoldingKey = timeHoldingKey + Time.deltaTime;
        if (lastKey != recordedLastKey)
        {
            recordedLastKey = lastKey;
            timeHoldingKey = 0;
        }
        else
        {
            switch (lastKey)
            {
                case "D":
                    {
                        //Debug.Log("D");
                        if(fowardAnim > 0.1f || fowardAnim < -0.1f)
                        {
                            if (fowardAnim > 0.1f)
                            {
                                fowardAnim = fowardAnim - speed * timeFlow;
                            }
                            else if (fowardAnim < -0.1f)
                            {
                                fowardAnim = fowardAnim + speed * timeFlow;
                            }
                        }
                        else
                        {
                            fowardAnim = 0;
                        }
                        if (rightAnim < 1)
                        {
                            rightAnim = rightAnim + speed * timeFlow;
                        }
                       
                        break;
                    }
                case "DW":
                    {
                        //Debug.Log("DW");
                        if (rightAnim < 1)
                        {
                            rightAnim = rightAnim + speed * timeFlow;
                        }
                        if (fowardAnim < 1)
                        {
                            fowardAnim = fowardAnim + speed * timeFlow;
                        }
                        break;
                    }
                case "DS":
                    {
                        //Debug.Log("DS");
                        if (rightAnim < 1)
                        {
                            rightAnim = rightAnim + speed * timeFlow;
                        }
                        if (fowardAnim > -1)
                        {
                            fowardAnim = fowardAnim - speed * timeFlow;
                        }
                        break;
                    }
                case "S":
                    {
                        //Debug.Log("S");
                        if (rightAnim > 0.1f || rightAnim < -0.1f)
                        {
                            if (rightAnim > 0.1f)
                            {
                                rightAnim = rightAnim - speed * timeFlow;
                            }
                            else if (rightAnim < -0.1f)
                            {
                                rightAnim = rightAnim + speed * timeFlow;
                            }
                        }
                        else
                        {
                            rightAnim = 0;
                        }
                        if (fowardAnim > -1)
                        {
                            fowardAnim = fowardAnim - speed * timeFlow;
                        }
                        break;
                    }
                case "SA":
                    {
                        //Debug.Log("SA");
                        if (rightAnim > -1)
                        {
                            rightAnim = rightAnim - speed * timeFlow;
                        }
                        if (fowardAnim > -1)
                        {
                            fowardAnim = fowardAnim - speed * timeFlow;
                        }
                        break;
                    }
                case "A":
                    {
                        //Debug.Log("A");
                        if (fowardAnim > 0.1f || fowardAnim < -0.1f)
                        {
                            if (fowardAnim > 0.1f)
                            {
                                fowardAnim = fowardAnim - speed * timeFlow;
                            }
                            else if (fowardAnim < -0.1f)
                            {
                                fowardAnim = fowardAnim + speed * timeFlow;
                            }
                        }
                        else
                        {
                            fowardAnim = 0;
                        }
                        if (rightAnim > -1)
                        {
                            rightAnim = rightAnim - speed * timeFlow;
                        }
                        break;
                    }
                case "AW":
                    {
                        //Debug.Log("AW");
                        if (rightAnim > - 1)
                        {
                            rightAnim = rightAnim - speed * timeFlow;
                        }
                        if (fowardAnim < 1)
                        {
                            fowardAnim = fowardAnim + speed * timeFlow;
                        }
                        break;
                    }
                case "W":
                    {
                        //Debug.Log("W");
                        if (rightAnim > 0.1f || rightAnim < -0.1f)
                        {
                            if (rightAnim > 0.1f)
                            {
                                rightAnim = rightAnim - speed * timeFlow;
                            }
                            else if (rightAnim < -0.1f)
                            {
                                rightAnim = rightAnim + speed * timeFlow;
                            }
                        }
                        else
                        {
                            rightAnim = 0;
                        }
                        if (fowardAnim < 1)
                        {
                            fowardAnim = fowardAnim + speed * timeFlow;
                        }
                        break;
                    }
                case "No Key":
                    {
                        //Debug.Log("NoKey");
                        //Debug.Log(fowardAnim + " > 0.1f  && " + fowardAnim + " < -0.1f " + timeFlow);
                        if (fowardAnim > 0.1f || fowardAnim < -0.1f)
                        {
                            if (fowardAnim > 0.1f)
                            {
                                fowardAnim = fowardAnim - speed * timeFlow;
                            }
                            else if (fowardAnim < -0.1f)
                            {
                                fowardAnim = fowardAnim + speed * timeFlow;
                            }
                            //Debug.LogError(fowardAnim);
                        }
                        else
                        {
                            fowardAnim = 0;
                        }
                        //Debug.Log(rightAnim + " > 0.1f  && " + rightAnim + " < -0.1f");
                        if (rightAnim > 0.1f || rightAnim < -0.1f)
                        {
                            if (rightAnim > 0.1f)
                            {
                                rightAnim = rightAnim - speed * timeFlow;
                            }
                            else if (rightAnim < -0.1f)
                            {
                                rightAnim = rightAnim + speed * timeFlow;
                            }
                        }
                        else
                        {
                            rightAnim = 0;
                        }
                        break;
                    }
            }
            AnimeRobot.SetFloat("Foward", fowardAnim);
            AnimeRobot.SetFloat("Right", rightAnim);
        }
        if (interact == true && interactionTime > 0.4f)
        {
            raio.origin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            raio.direction = fpsCam.transform.forward;
            if (Physics.Raycast(raio, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Button"))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.DrawLine(raio.origin, hit.point, Color.blue, 5);
                    AnimeRobot.SetBool("HoldPress", true);
                }
                Debug.Log(hit.collider.gameObject.layer + " " + (Vector3.Distance(hit.point, Player_.transform.position)));
                Debug.DrawLine(hit.point, Player_.transform.position,Color.black,4);
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Hold"))
                {
                    //if (Vector3.Distance(hit.collider.transform.position, Player_.transform.position) < 2.2f)
                    //{
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.Log("Distancia entre o Player e a chave " + Vector3.Distance(hit.collider.transform.position, Player_.transform.position));
                    Debug.DrawLine(raio.origin, hit.point, Color.blue, 5);
                    SendMessage("GrabIt", hit.collider.gameObject);
                    AnimeRobot.SetBool("HoldPress", true);
                    groundDetection.SendMessage("CubeColor", hit.collider.gameObject.tag);
                    //}
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ActiveRange") || Vector3.Distance(hit.point, Player_.transform.position) < 2.2f)
                {
                    groundDetection.SendMessage("CubeColor", "White");
                    Debug.Log("DropIt");
                    SendMessage("DropIt", hit.point);
                }
            }            
            interactionTime = 0;
        }
        interact = false;
        if (jump == true)
        {
            AnimeRobot.SetBool("Jump", true);
            jump = false;
        }
        if(MoveKey == true)
        {
            AnimeRobot.SetBool("Move", true);
            MoveKey = false;
        }
        else
        {
            AnimeRobot.SetBool("Move", false);
        }
    }

    private void PlayerMouse()
    {//https://forum.unity.com/threads/mouse-look-script.233903/
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            _Camera.transform.localEulerAngles = new Vector3(-rotationY,0 , 0);
            transform.localEulerAngles = new Vector3(0, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            _Camera.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, _Camera.transform.localEulerAngles.y, 0);
        }
    }
    public GameObject _Camera;
    public int minX, maxX;
    Vector2 mouse;

    ////////
    //
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    private Rigidbody rb;
    float rotationY = 0F;

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {//https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-196526
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}
