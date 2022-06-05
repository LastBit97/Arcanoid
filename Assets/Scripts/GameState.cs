using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    Gameplay,
    StopGame
}

public class GameState : MonoBehaviour
{
    public State State { get; private set; }

    public void SetState(State state)
    {
        State = state;

        if (State == State.Gameplay)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
