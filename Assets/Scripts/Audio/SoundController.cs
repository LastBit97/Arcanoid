using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    private SoundState _soundState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _soundState = new SoundState();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeSound()
    {
        _soundState.EnableSound(!_soundState.GetSound());
    }

    public bool IsSoundOn()
    {
        return _soundState.GetSound();
    }

}
