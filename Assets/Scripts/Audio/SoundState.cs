using UnityEngine;

public class SoundState
{
    private bool _sound;
    private const string Key = "Sound";

    public bool GetSound()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            _sound = PlayerPrefs.GetInt(Key) == 1;
        }
        else
        {
            _sound = true;
            Save();
        }

        return _sound;
    }
    public void EnableSound(bool value)
    {
        _sound = value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(Key, _sound ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey(Key);
    }
}
