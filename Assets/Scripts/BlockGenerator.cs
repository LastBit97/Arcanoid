using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] private List<BlockData> blocks;

    private void Start()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            GameObject game = Instantiate(blocks[i].Prefab, new Vector3(0 + i, 0, 0), Quaternion.identity);
            if (game.TryGetComponent(out Block block))
            {
                block.SetData(blocks[i]);
            }
        }
    }
}
