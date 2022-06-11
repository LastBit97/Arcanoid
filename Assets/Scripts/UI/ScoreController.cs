using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEventInt UiUpdate;
    [SerializeField] private UnityEvent ThousandCollected;
    private const int ScoreToNextBonus = 1500;

    public int Score { get; private set; }

    public void SetDefault()
    {
        Score = 0;
        UiUpdate.Invoke(Score);
    }

    private void OnEnable()
    {
        Block.OnDestroyed += ScoreCollect;
        Bonus.OnAdded += ScoreCollect;
        Ufo.OnDestroyed += ScoreCollect;
    }

    private void OnDisable()
    {
        Block.OnDestroyed -= ScoreCollect;
        Bonus.OnAdded -= ScoreCollect;
        Ufo.OnDestroyed -= ScoreCollect;
    }

    private void ScoreCollect(int value)
    {
        if (_gameState.State == State.Gameplay)
        {
            Score += value;
            UiUpdate.Invoke(Score);
            if (Score % ScoreToNextBonus == 0)
            {
                ThousandCollected.Invoke();
            }
        }
    }
}
