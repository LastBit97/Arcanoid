using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private SoundButton _sound;

    private void OnEnable()
    {
        _sound.SetState(SoundController.Instance.IsSoundOn());
    }

    public void ChangeSound()
    {
        SoundController.Instance.ChangeSound();
    }

    public void ClearProgress()
    {
        LevelIndex levelIndex = new LevelIndex();
        levelIndex.Clear();
        LevelsData levelsData = new LevelsData();
        levelsData.Clear();
        SceneManager.LoadSceneAsync("Main");
    }
}
