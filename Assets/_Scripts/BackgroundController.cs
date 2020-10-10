using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed; 
    public float verticalBoundary = 10;
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        var newPosition = new Vector3(0.0f, verticalSpeed, 0.0f);
        transform.position -= newPosition;
    }
    private void Reset()
    {
        transform.position = new Vector3(0,verticalBoundary,0);
    }
    private void CheckBounds()
    {
        if(transform.position.y <= -verticalBoundary)
        {
            Reset();
        }
    }
}
