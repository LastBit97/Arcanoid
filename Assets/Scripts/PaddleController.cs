using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 10.0f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float borderPosition = 2.4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        PaddleControl();
    }

    private void PaddleControl()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float positionX = rb.position.x + horizontalInput * Time.fixedDeltaTime * speed;
        positionX = Mathf.Clamp(positionX, -borderPosition + (sr.size.x / 2), borderPosition - (sr.size.x / 2));
        rb.MovePosition(new Vector2(positionX, rb.position.y));
    }
}
