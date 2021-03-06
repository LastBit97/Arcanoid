using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    private readonly LevelIndex _levelIndex = new LevelIndex();
    private readonly BlocksGenerator _blocksGenerator = new BlocksGenerator();
    [SerializeField] private Transform _parentBlocks;
    [SerializeField] private ClearLevel _clearLevel;
    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEvent OnGenerated;

    private void Start()
    {
        _gameState.SetState(State.StopGame);
        Generate();
    }

    public void Generate()
    {
        _clearLevel.Clear();
        GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{_levelIndex.GetIndex() + 1}");
        if (gameLevel != null)
        {
            _blocksGenerator.Generate(gameLevel, _parentBlocks);
        }
        _gameState.SetState(State.Gameplay);
        OnGenerated?.Invoke();
    }

    public void GenerateNext()
    {
        LevelsData levelsData = new LevelsData();
        int index = _levelIndex.GetIndex();
        if (index < levelsData.GetLevelsProgress().Levels.Count - 1)
        {
            _levelIndex.SetIndex(index + 1);
            Generate();
        }
        else
        {
            SceneManager.LoadSceneAsync("Main");
        }
    }
}
