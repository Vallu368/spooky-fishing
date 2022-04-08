using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Quaternion forwardRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion downRotation = Quaternion.Euler(40, 0, 0);
    private Quaternion leftRotation = Quaternion.Euler(0, -80, 0);
    private Quaternion rightRotation = Quaternion.Euler(0, 80, 0);
    private Quaternion backLeftRotation = Quaternion.Euler(0, -155, 0);
    private Quaternion backRightRotation = Quaternion.Euler(0, -195, 0);

    public int rotateSpeed = 100;
    public int time = 0;

    public bool inMotion = false;
    public bool lookForward = false;
    public bool lookDown = false;
    public bool lookLeft = false;
    public bool lookRight = false;
    public bool lookBackRight = false;
    public bool lookBackLeft = false;

    private int nextUpdate = 1;

    public void Start()
    {
        transform.rotation = downRotation;
        lookDown = true;
    }
    private void Update()
    {
        if (inMotion == false) //ottaa inputteja vaan jos kamera ei ole jo liikkumassa
        {
            MovementInputs();
        }
        Movement();
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
        if (inMotion)
        {
            time = 0;
        }
    }

    void UpdateEverySecond()
    {
        time++;
    }

    void MovementInputs()
    {
        if (Input.GetKey("w"))
        {
            if (lookDown)
            {
                lookForward = true; 
                Debug.Log("Looking forward...");
                inMotion = true;

                lookDown = false;
                lookLeft = false;
                lookRight = false;
                lookBackLeft = false;
                lookBackRight = false;
            }
        }
        if (Input.GetKey("s"))
        {
            if (!lookDown)
			{
                lookDown = true;
                Debug.Log("Looking down...");
                inMotion = true;

                lookForward = false;
                lookLeft = false;
                lookRight = false;
                lookBackLeft = false;
                lookBackRight = false;
            }
        }
        if (Input.GetKey("a"))
        {
            if (lookForward || lookDown)
            {
                lookLeft = true; 
                Debug.Log("Looking left...");
                inMotion = true;

                lookDown = false;
                lookForward = false;
                lookRight = false;
                lookBackRight = false;
                lookBackLeft = false;
            }
            else if  (lookRight)
            {
                lookForward = true;
                Debug.Log("Looking forward...");
                inMotion = true;

                lookLeft = false;
                lookRight = false;
                lookDown = false;
                lookBackLeft = false;
                lookBackRight = false;
            }
            else if (transform.rotation == leftRotation)
            {
                lookBackLeft = true;
                Debug.Log("Looking back-left...");
                inMotion = true;

                lookLeft = false;
            
           }
            else if (lookBackRight)
            {
                lookRight = true;
                Debug.Log("Looking right...");
                inMotion = true;

                lookBackRight = false;
                lookBackLeft = false;
                lookForward = false;
                lookDown = false;
                lookLeft = false;
            }
            
        }
        if (Input.GetKey("d"))
        {
            if (lookDown || lookForward)
            {
                lookRight = true;
                Debug.Log("Looking right...");
                inMotion = true;

                lookForward = false;
                lookDown = false;
                lookLeft = false;
                lookBackLeft = false;
                lookBackRight = false;
            }
            else if (lookLeft)
            {
                lookForward = true;
                Debug.Log("Looking forward...");
                inMotion = true;

                lookLeft = false;
                lookRight = false;
                lookDown = false;
                lookBackLeft = false;
                lookBackRight = false;
            }
            else if (lookBackLeft)
            {
                lookLeft = true;
                Debug.Log("Looking left...");
                inMotion = true;

                lookBackLeft = false;
                lookBackRight = false;
                lookRight = false;
                lookForward = false;
                lookDown = false;
            }
            else if (transform.rotation == rightRotation)
            {
                lookBackRight = true;
                Debug.Log("Looking back-right...");
                inMotion = true;

                lookRight = false;
                lookLeft = false;
                lookForward = false;
                lookDown = false;
                lookBackLeft = false;
            }
        }
        }
    

    void Movement()
    {
        if (lookForward)
        {
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, forwardRotation, Time.deltaTime * rotateSpeed);
            if (transform.rotation == forwardRotation)
            {
                inMotion = false;
            }
        }
        if (lookDown)
        {
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, downRotation, Time.deltaTime * rotateSpeed);
                
            if (transform.rotation == downRotation)
            {
                inMotion = false;
            }
        }
        if (lookLeft)
        {
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, leftRotation, Time.deltaTime * rotateSpeed);

            if (transform.rotation == leftRotation)
            {
                inMotion = false;
            }
        }
        if (lookRight)
        {
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, rightRotation, Time.deltaTime * rotateSpeed);

            if (transform.rotation == rightRotation)
            {
                inMotion = false;
            }
        }
        if (lookBackLeft)
        {
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, backLeftRotation, Time.deltaTime * rotateSpeed);

            if (transform.rotation == backLeftRotation)
            {
                inMotion = false;
            }
        }
        if (lookBackRight)
        {
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, backRightRotation, Time.deltaTime * rotateSpeed);

            if (transform.rotation == backRightRotation)
            {
                inMotion = false;
            }
        }
    }
}
