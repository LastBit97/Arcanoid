using UnityEngine;

public class UfoGenerator : MonoBehaviour
{
    private const float MinPositionY = -1.5f;
    private const float MaxPositionY = 3.5f;
    private ObjectPool _ufosPool;

    private void OnEnable()
    {
        if (_ufosPool == null)
        {
            ObjectPool[] objectPools = FindObjectsOfType<ObjectPool>();
            for (int i = 0; i < objectPools.Length; i++)
            {
                if (objectPools[i].gameObject.CompareTag("UfosPool"))
                {
                    _ufosPool = objectPools[i];
                    break;
                }
            }
        }
    }

    public void Generate()
    {
        GameObject ufo = _ufosPool.GetObject();
        if (ufo != null)
        {
            float tempY = Random.Range(MinPositionY, MaxPositionY);
            ufo.transform.position = new Vector2(transform.position.x, tempY);
            ufo.SetActive(true);
        }
    }
}
