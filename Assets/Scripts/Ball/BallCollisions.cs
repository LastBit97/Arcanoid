using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    [SerializeField] private BallMove _ball;


    private void Awake()
    {
        _ball = GetComponent<BallMove>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PaddleController paddle))
        {
            float touchPointX = collision.contacts[0].point.x;
            float paddleCenterX = paddle.gameObject.GetComponent<Transform>().position.x;
            float differenceX = paddleCenterX - touchPointX; // разница между центром и точкой касания
            float directionBall = touchPointX < paddleCenterX ? -1 : 1;
            _ball.Move(directionBall * Mathf.Abs(differenceX));
        }

        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage();
        }
    }
}
