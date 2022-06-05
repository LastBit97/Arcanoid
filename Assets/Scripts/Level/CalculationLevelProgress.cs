using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationLevelProgress : MonoBehaviour
{
    [SerializeField] private PlayerLife _playerLife;
    [SerializeField] private ScoreController _scoreController;
    private Progress _progress = new Progress();
    private readonly LevelsData _levelsData = new LevelsData();
    private readonly LevelIndex _levelIndex = new LevelIndex();
    private EndGameData _endGameData;


    private void Calculate()
    {
        int index = _levelIndex.GetIndex();
        _progress = _levelsData.GetLevelsProgress().Levels[index];


        _endGameData = new EndGameData()
        {
            LevelIndex = _levelIndex.GetIndex(),
            Life = _playerLife.Life,
            Score = _scoreController.Score,
            Record = _progress.MaxScore
        };

        if (_playerLife.Life > 0)
        {
            SaveLevelProgress();
        }
    }

    private void SaveLevelProgress()
    {
        if (_endGameData.Record < _endGameData.Score)
        {
            _endGameData.Record = _endGameData.Score;
            _progress.MaxScore = _endGameData.Score;
        }
        if (_progress.StarsCount < _endGameData.Life)
        {
            _progress.StarsCount = _endGameData.Life;
        }
        _levelsData.SaveLevelData(_levelIndex.GetIndex(), _progress);
    }

    public EndGameData GetEndGameData()
    {
        Calculate();
        return _endGameData;
    }
}

public struct EndGameData
{
    public int LevelIndex;
    public int Life;
    public int Score;
    public int Record;
}
