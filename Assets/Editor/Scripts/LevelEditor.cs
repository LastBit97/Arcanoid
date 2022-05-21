using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelEditor : EditorWindow
{
    private const string AssetPath = "Assets/Editor/Data/EditorData.asset";

    private Transform _parent;
    private EditorData _data;
    private int _index;

    [MenuItem("Window/Level Editor")]
    public static void Init()
    {
        LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
        levelEditor.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
        EditorGUILayout.Space(10);

        if (_data == null)
        {
            if (GUILayout.Button("Load data"))
            {
                _data = (EditorData)AssetDatabase.LoadAssetAtPath(AssetPath, typeof(EditorData));
            }
        }
        else
        {
            #region Подпись
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Block Prefub", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUI.color = Color.red;
            #region Кнопка <
            if (GUILayout.Button("<", GUILayout.Width(35), GUILayout.Height(35)))
            {
                _index--;
                if (_index < 0)
                {
                    _index = _data.BlockDatas.Count - 1;
                }
            } 
            #endregion

            var blockData = _data.BlockDatas[_index].BlockData;
            GUI.color = blockData.BaseColor;
            GUILayout.Label(_data.BlockDatas[_index].Texture2D);
            GUI.color = Color.white;

            #region Кнопка >
            if (GUILayout.Button(">", GUILayout.Width(35), GUILayout.Height(35)))
            {
                _index++;
                if (_index > _data.BlockDatas.Count - 1)
                {
                    _index = 0;
                }
            } 
            #endregion

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();


        }
    }

}
