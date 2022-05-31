using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private readonly LevelIndex _levelIndex = new LevelIndex();
    private readonly BlocksGenerator _blocksGenerator = new BlocksGenerator();
    [SerializeField] private Transform _parentBlocks;
    [SerializeField] private ClearLevel _clearLevel;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        _clearLevel.Clear();
        GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{_levelIndex.GetIndex()}");
        if (gameLevel != null)
        {
            _blocksGenerator.Generate(gameLevel, _parentBlocks);
        }
    }
}
