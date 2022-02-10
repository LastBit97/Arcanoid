using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private static int count = 0;

    private List<Sprite> sprites;
    private int score;
    private SpriteRenderer spriteRenderer;
    private int life;

    public void SetData(BlockData blockData)
    {
        sprites = new List<Sprite>(blockData.Sprites);
        score = blockData.Score;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = blockData.BaseColor;
        life = sprites.Count;
        spriteRenderer.sprite = sprites[life - 1];
    }

    public void ApplyDamage()
    {
        life--;
        if (life < 1)
        {
            Destroy(gameObject);
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
