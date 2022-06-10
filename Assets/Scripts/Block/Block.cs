using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Block : MonoBehaviour, IDamageable
{
    private static int _count = 0;

    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private int _score;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private int _life;

    public static event Action OnEnded;
    public static event Action<int> OnDestroyed;
    public static event Action<Vector2> OnDestroyedPosition;

#if UNITY_EDITOR
    public BlockData BlockData;
#endif

    public void SetData(BlockData blockData)
    {
        _sprites = new List<Sprite>(blockData.Sprites);
        _score = blockData.Score;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = blockData.BaseColor;
        _life = _sprites.Count;
        _spriteRenderer.sprite = _sprites[_life - 1];
        MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = _spriteRenderer.color;
    }

    public void ApplyDamage()
    {
        _life--;
        if (_life < 1)
        {
            _spriteRenderer.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            OnDestroyed?.Invoke(_score);
            OnDestroyedPosition?.Invoke(transform.position);
            GetComponent<ParticleSystem>().Play();
        }
        else
        {
            _spriteRenderer.sprite = _sprites[_life - 1];
        }
    }

    private void OnEnable()
    {
        _count++;
    }

    private void OnDisable()
    {
        _count--;
        
        if (_count < 1)
        {
            OnEnded?.Invoke();
        }
    }

}
