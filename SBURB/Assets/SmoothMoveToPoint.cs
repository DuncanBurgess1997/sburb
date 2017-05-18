using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMoveToPoint : MonoBehaviour
{
    private Vector3 finalPos;
    public bool moving = false;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    void Update()   
    {
        if (moving)
        {
            transform.position = Vector3.SmoothDamp(transform.position, finalPos, ref velocity, smoothTime);

            if ((transform.position.x <= finalPos.x + 0.001 && transform.position.x >= finalPos.x) || transform.position.x >= finalPos.x - 0.001)
            {
                if ((transform.position.y <= finalPos.y + 0.001 && transform.position.y >= finalPos.y) || (transform.position.y >= finalPos.y - 0.001 && transform.position.y <= finalPos.y))
                {
                    if ((transform.position.z <= finalPos.z + 0.001 && transform.position.z >= finalPos.z) || transform.position.z >= finalPos.x - 0.001)
                    {
                        moving = false;
                    }
                }
            }
        }
    }

    public void MoveToPoint(Vector3 target)
    {
        if (!moving)
        {
            finalPos = target;
            moving = true;
        }
    }
}
