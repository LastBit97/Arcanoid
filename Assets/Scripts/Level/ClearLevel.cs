using UnityEngine;

public class ClearLevel : MonoBehaviour
{
    public void Clear()
    {
        Block[] allBlocks = FindObjectsOfType<Block>();
        if (allBlocks.Length > 0)
        {
            foreach (var item in allBlocks)
            {
                DestroyItem(item.gameObject);
            }
        }

        BallMove[] allBalls = FindObjectsOfType<BallMove>();
        if (allBalls.Length > 0)
        {
            foreach (var item in allBalls)
            {
                DestroyItem(item.gameObject);
            }
        }

        Bonus[] bonuses = FindObjectsOfType<Bonus>();
        if (bonuses.Length > 0)
        {
            foreach (var item in bonuses)
            {
                DestroyItem(item.gameObject);
            }
        }

        Bullet[] bullets = FindObjectsOfType<Bullet>();
        if (bullets.Length > 0)
            foreach (var item in bullets)
            {
                item.gameObject.SetActive(false);
            }
    }

    private void DestroyItem(GameObject game)
    {
#if UNITY_EDITOR
        DestroyImmediate(game.gameObject);
#else
                    Destroy(game.gameObject);
#endif
    }
}
