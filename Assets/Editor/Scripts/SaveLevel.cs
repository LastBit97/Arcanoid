using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevel
{
    public List<BlockObject> GetBlocks()
    {
        List<BlockObject> blocks = new List<BlockObject>();
        GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("Block");


        foreach (var item in allBlocks)
        {
            BlockObject blockObject = new BlockObject
            {
                Position = item.gameObject.transform.position
            };

            if (item.TryGetComponent(out Block block))
            {
                blockObject.Block = block.BlockData;
            }
            blocks.Add(blockObject);
        }
        return blocks;
    }
}
