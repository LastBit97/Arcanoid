using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float _speed = 5.0f;

    private Rigidbody2D _rigidBody2d;
    private SpriteRenderer _spriteRenderer;

    private float borderPosition = 2.4f;
    private float _moveX = 0f;

    void Awake()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        PaddleControl();
    }

    private void PaddleControl()
    {
        float positionX = _rigidBody2d.position.x + _moveX * Time.fixedDeltaTime * _speed;
        positionX = Mathf.Clamp(positionX, -borderPosition + (_spriteRenderer.size.x / 2), borderPosition - (_spriteRenderer.size.x / 2));
        _rigidBody2d.MovePosition(new Vector2(positionX, _rigidBody2d.position.y));
    }

    private void OnEnable()
    {
        PlayerInput.OnMove += Move;
    }

    private void OnDisable()
    {
        PlayerInput.OnMove -= Move;
    }

    private void Move(float moveX)
    {
        _moveX = moveX;
    }
}
