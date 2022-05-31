﻿using UnityEngine;

public class LevelIndex
{
    private const string KeyName = "Index";

    public void SetIndex(int index)
    {
        PlayerPrefs.SetInt(KeyName, index);
    }

    public int GetIndex()
    {
        int index = 1;
        if (PlayerPrefs.HasKey(KeyName))
        {
            index = PlayerPrefs.GetInt(KeyName);
        }

        return index;
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey(KeyName);
    }
}