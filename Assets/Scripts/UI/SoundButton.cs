using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [Space]
    [SerializeField] private Image _icon;
    [Space]
    [SerializeField] private Sprite _enableSprite;
    [SerializeField] private Sprite _disableSprite;
    private bool _enable;

    public void SetState(bool value)
    {
        _enable = value;
        ChangeIcon();
    }

    public void ChangeState()
    {
        _enable = !_enable;
        ChangeIcon();
    }

    private void ChangeIcon()
    {
        _icon.sprite = _enable ? _enableSprite : _disableSprite;
    }
}
