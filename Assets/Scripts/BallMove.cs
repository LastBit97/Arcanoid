using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private bool isActive;
    private const float Force = 300;
    private const float OffsetX = 100;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ballRb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BallActivate();
        }
    }

    private void BallActivate()
    {
        isActive = true;
        transform.SetParent(null);
        ballRb.bodyType = RigidbodyType2D.Dynamic;
        ballRb.AddForce(new Vector2(OffsetX, Force));
    }
}
