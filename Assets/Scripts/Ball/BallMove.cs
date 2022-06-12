using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRb;
    private bool isActive;
    private const float ForceY = 250;
    [Range(-3f, 3f)]
    [SerializeField] private float _forceX;
    [SerializeField] private BallSound _ballSound;

    private void BallActivate()
    {
        if (!isActive)
        {
            isActive = true;
            transform.SetParent(null);
            ballRb.bodyType = RigidbodyType2D.Dynamic;
            Move(_forceX); // м€ч стартует строго вверх 
            _ballSound.PlaySoundAwake();
        }
    }

    public void Move(float forceX = 0f)
    {
        ballRb.velocity = Vector2.zero;
        ballRb.AddForce(new Vector2(forceX * (ForceY / 2), ForceY));
    }

    private void OnEnable()
    {
        ballRb.bodyType = RigidbodyType2D.Kinematic;
        PlayerInput.OnClicked += BallActivate;
    }

    private void OnDisable()
    {
        PlayerInput.OnClicked -= BallActivate;
    }

    public void StartClone(float direction)
    {
        isActive = true;
        ballRb.bodyType = RigidbodyType2D.Dynamic;
        Move(direction);
    }
}
