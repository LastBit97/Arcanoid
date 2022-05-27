using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevel
{
    public void Save(GameLevel gameLevel)
    {
        gameLevel.Blocks = new List<BlockObject>();
        Block[] blocks = GameObject.FindObjectsOfType<Block>();


        foreach (var item in blocks)
        {
            BlockObject blockObject = new BlockObject
            {
                Position = item.gameObject.transform.position,

                Block = item.BlockData
            };

            gameLevel.Blocks.Add(blockObject);
        }
    }
}
