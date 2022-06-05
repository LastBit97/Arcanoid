using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour
{
    private const int MAX_LIFE = 3;

    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEvent OnAllLifeLosted;
    [SerializeField] private UnityEvent OnLifeLosted;
    [SerializeField] private UnityEventInt UiUpdate;

    public int Life { get; private set; }

    public void SetDefault()
    {
        Life = MAX_LIFE;
        UiUpdate.Invoke(Life);
    }

    private void OnEnable()
    {
        BallCount.OnEnded += LostLife;
    }

    private void OnDisable()
    {
        BallCount.OnEnded -= LostLife;
    }

    private void LostLife()
    {
        if (_gameState.State == State.Gameplay)
        {
            Life--;
            if (Life < 1)
            {
                OnAllLifeLosted.Invoke();
            }
            else
            {
                OnLifeLosted.Invoke();
            }

            UiUpdate.Invoke(Life);
        }
    }
}

[System.Serializable]
public class UnityEventInt : UnityEvent<int> { }
