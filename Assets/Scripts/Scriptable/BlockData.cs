using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "GameData/Create/Block")]
public class BlockData : ScriptableObject
{
    public GameObject Prefab;
    public List<Sprite> Sprites;
    public Color BaseColor;
    public int Score;
}
