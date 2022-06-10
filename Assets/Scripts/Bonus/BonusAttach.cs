using UnityEngine;

[RequireComponent(typeof(BonusMove), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class BonusAttach : MonoBehaviour
{
    [SerializeField] private BonusMove _bonusMove;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Space]
    [SerializeField] private Bonus _bonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PaddleController paddleController))
        {
            SetEnableMoveAndVisual(false);
            Attach(paddleController.transform);
        }
    }

    private void Attach(Transform parent)
    {
        transform.SetParent(parent);
        transform.position = parent.position;
        _bonus.Apply();
    }

    private void OnEnable()
    {
        SetEnableMoveAndVisual(false);
    }

    public void SetEnableMoveAndVisual(bool value)
    {
        _boxCollider2D.enabled = value;
        _spriteRenderer.enabled = value;
        _bonusMove.enabled = value;
    }
}
