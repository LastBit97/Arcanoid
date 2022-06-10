using System.Collections;
using UnityEngine;

public class PaddleSizeBonus : Bonus
{
    [SerializeField] private bool _negative;
    private const float Size = 0.5f;
    private const float WaitingTime = 2f;

    public override void Apply()
    {
        base.Apply();
        StartTimer();
        SetSize(_negative ? -Size : Size);
    }

    private void Remove()
    {
        SetSize(_negative ? Size : -Size);
    }

    private void SetSize(float value)
    {
        PaddleController paddle = GetComponentInParent<PaddleController>();
        if (paddle != null)
        {
            if (paddle.TryGetComponent(out SpriteRenderer spriteRenderer) && paddle.TryGetComponent(out BoxCollider2D boxCollider2D))
            {
                StartAnimateSize(spriteRenderer, boxCollider2D, value);
            }
        }
        
    }

    private void StartAnimateSize(SpriteRenderer spriteRenderer, BoxCollider2D boxCollider2D, float width)
    {
        StartCoroutine(AnimateSizeCoroutine(spriteRenderer, boxCollider2D, width));
    }

    private IEnumerator AnimateSizeCoroutine(SpriteRenderer paddle, BoxCollider2D boxCollider2D, float width)
    {
        float currentWidth = paddle.size.x;
        float newWidth = currentWidth + width;
        if (newWidth > currentWidth)
        {
            while (currentWidth < newWidth)
            {
                currentWidth += Time.deltaTime * 2;
                paddle.size = new Vector2(currentWidth, paddle.size.y);
                boxCollider2D.size = new Vector2(currentWidth, boxCollider2D.size.y);
                yield return null;
            }
            paddle.size = new Vector2(newWidth, paddle.size.y);
            boxCollider2D.size = new Vector2(newWidth, boxCollider2D.size.y);
        }
        else if (newWidth < currentWidth)
        {
            while (currentWidth > newWidth)
            {
                currentWidth -= Time.deltaTime * 2;
                paddle.size = new Vector2(currentWidth, paddle.size.y);
                boxCollider2D.size = new Vector2(currentWidth, boxCollider2D.size.y);
                yield return null;
            }
            paddle.size = new Vector2(newWidth, paddle.size.y);
            boxCollider2D.size = new Vector2(newWidth, boxCollider2D.size.y);
        }        
    }

    protected override IEnumerator Timer()
    {
        yield return base.Timer();
        Remove();
        yield return new WaitForSeconds(WaitingTime); // костыль, чтобы бонус уничтожался ПОСЛЕ того, как платформа вернет свой размер
        Destroy(gameObject);
    }
}

