using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float _speed = 5.0f;

    private Rigidbody2D _rigidBody2d;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private ParticleSystem _leftMuzzle;
    [SerializeField] private ParticleSystem _rightMuzzle;
    [SerializeField] private PaddleSound _paddleSound;

    private float borderPosition = 2.4f;
    private float _moveX = 0f;

    void Awake()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _leftMuzzle.Stop();
        _rightMuzzle.Stop();
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

    public void ResetPosition()
    {
        _rigidBody2d.position = new Vector2(0f, _rigidBody2d.position.y);
    }

    public void PlayEffects()
    {
        _leftMuzzle.Play();
        _rightMuzzle.Play();
        _paddleSound.PlaySoundShot();
    }
}
