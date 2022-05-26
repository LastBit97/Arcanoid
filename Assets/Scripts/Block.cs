using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Block : MonoBehaviour
{
    private static int count = 0;

    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private int score;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int life;

#if UNITY_EDITOR
    public BlockData BlockData;
#endif

    public void SetData(BlockData blockData)
    {
        sprites = new List<Sprite>(blockData.Sprites);
        score = blockData.Score;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = blockData.BaseColor;
        life = sprites.Count;
        spriteRenderer.sprite = sprites[life - 1];
        MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = spriteRenderer.color;
    }

    public void ApplyDamage()
    {
        life--;
        if (life < 1)
        {
            spriteRenderer.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<ParticleSystem>().Play();
        }
        else
        {
            spriteRenderer.sprite = sprites[life - 1];
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
