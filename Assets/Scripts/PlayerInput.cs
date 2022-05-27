using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action<float> OnMove;
    public static event Action OnClicked;

    private void Update()
    {
#if UNITY_EDITOR
        OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            OnClicked?.Invoke();
        }
#endif
    }
}
