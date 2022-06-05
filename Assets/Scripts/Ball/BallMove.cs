using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private bool isActive;
    private const float ForceY = 250;
    private void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ballRb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void BallActivate()
    {
        if (!isActive)
        {
            isActive = true;
            transform.SetParent(null);
            ballRb.bodyType = RigidbodyType2D.Dynamic;
            Move(); // м€ч стартует строго вверх 
        }
    }

    public void Move(float forceX = 0f)
    {
        ballRb.velocity = Vector2.zero;
        ballRb.AddForce(new Vector2(forceX * (ForceY / 2), ForceY));
    }

    private void OnEnable()
    {
        PlayerInput.OnClicked += BallActivate;
    }

    private void OnDisable()
    {
        PlayerInput.OnClicked -= BallActivate;
    }
}
