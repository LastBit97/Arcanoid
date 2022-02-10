using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private bool isActive;
    private const float Force = 250;
    private const float OffsetX = 100;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ballRb.bodyType = RigidbodyType2D.Kinematic;
    }

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
        //ballRb.AddForce(new Vector2(OffsetX, Force)); // ��� �������� ��� �����
        ballRb.AddForce(Vector2.up * Force); // ��� �������� ������ �����
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PaddleController paddle))
        {
            ballRb.velocity = Vector2.zero;
            float touchPointX = collision.contacts[0].point.x;
            float paddleCenterX = paddle.gameObject.GetComponent<Transform>().position.x;
            float differenceX = paddleCenterX - touchPointX; // ������� ����� ������� � ������ �������
            float directionBall = touchPointX < paddleCenterX ? -1 : 1;
            float forceX = directionBall * Mathf.Abs(differenceX * (Force / 2));

            ballRb.AddForce(new Vector2(forceX, Force));
        }
    }
}
