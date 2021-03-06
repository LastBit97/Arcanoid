using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    [SerializeField] private BallMove _ball;
    [SerializeField] private BallSound _ballSound;


    private void Awake()
    {
        _ball = GetComponent<BallMove>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ballSound.PlaySoundCollision();
        if (collision.gameObject.TryGetComponent(out PaddleController paddle))
        {
            float touchPointX = collision.contacts[0].point.x;
            float paddleCenterX = paddle.gameObject.GetComponent<Transform>().position.x;
            float differenceX = paddleCenterX - touchPointX; // ??????? ????? ??????? ? ?????? ???????
            float directionBall = touchPointX < paddleCenterX ? -1 : 1;
            _ball.Move(directionBall * Mathf.Abs(differenceX));
        }

        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage();
        }
    }
}
