using System;
using System.Collections;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] protected int _score;
    [SerializeField] protected float _time = 4f;
    private float _currentTime;
    private const float TimeStep = 0.5f;   

    public static event Action<int> OnAdded;

    public virtual void Apply()
    {
        OnAdded?.Invoke(_score);
    }

    protected void StartTimer()
    {        
        _currentTime = _time;
        StartCoroutine(Timer());
    }

    protected virtual IEnumerator Timer()
    {
        while (_currentTime > 0)
        {
            _currentTime -= TimeStep;
            yield return new WaitForSeconds(TimeStep);
        }      
    }
}
