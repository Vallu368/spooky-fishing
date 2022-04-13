using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markoscript : MonoBehaviour
{
    public bool isLightOn;
    MeshRenderer rend;

    public bool leftSide = false;
    public bool rightSide = false;
    public bool front = false;
    public bool backRight = false;
    public bool backLeft = false;
    private void Move(Vector3 target, float movementspeed)
    {
        transform.position += (target - transform.position).normalized * movementspeed * Time.deltaTime;
    }

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        if (isLightOn)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }


    }
}
