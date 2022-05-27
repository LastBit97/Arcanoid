using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Block : MonoBehaviour, IDamageable
{
    private static int count = 0;

    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private int _score;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private int _life;

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
            GetComponent<ParticleSystem>().Play();
        }
        else
        {
            _spriteRenderer.sprite = _sprites[_life - 1];
        }
    }

    private void OnEnable()
    {
        count++;
    }

    private void OnDisable()
    {
        count--;
        if (count < 1)
        {
            Debug.Log("Блоки закончились");
        }
    }

}
