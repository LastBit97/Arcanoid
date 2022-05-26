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
    private bool _isEnabledEdit;
    private SceneEditor _sceneEditor;

    private GameLevel _gameLevel;

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
                _sceneEditor = CreateInstance<SceneEditor>();
                _sceneEditor.SetLevelEditor(this, _parent);
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

            if (GUILayout.Button("<", GUILayout.Width(35), GUILayout.Height(35)))
            {
                _index--;
                if (_index < 0)
                {
                    _index = _data.BlockDatas.Count - 1;
                }
            }

            var blockData = _data.BlockDatas[_index].BlockData;
            GUI.color = blockData.BaseColor;
            GUILayout.Label(_data.BlockDatas[_index].Texture2D);
            GUI.color = Color.white;

            if (GUILayout.Button(">", GUILayout.Width(35), GUILayout.Height(35)))
            {
                _index++;
                if (_index > _data.BlockDatas.Count - 1)
                {
                    _index = 0;
                }
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(30);

            if (_parent != null)
            {
                GUI.color = _isEnabledEdit ? Color.red : Color.white;
                if (GUILayout.Button("Create blocks"))
                {
                    _isEnabledEdit = !_isEnabledEdit;

                    if (_isEnabledEdit)
                    {
                        SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
                    }
                    else
                    {
                        SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
                    }
                } 
            }

            GUI.color = Color.white;
            GUILayout.Space(30);

            _gameLevel = EditorGUILayout.ObjectField(_gameLevel, typeof(GameLevel), false) as GameLevel;

            if (_gameLevel != null)
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Save Level"))
                {
                    SaveLevel saveLevel = new SaveLevel();
                    _gameLevel.Blocks = saveLevel.GetBlocks();
                    EditorUtility.SetDirty(_gameLevel);
                    Debug.Log("Level saved");
                }

                if (GUILayout.Button("Load Level"))
                {
                    GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("Block");
                    foreach (var item in allBlocks)
                    {
                        DestroyImmediate(item.gameObject);
                    }

                    BlocksGenerator generator = new BlocksGenerator();
                    generator.Generate(_gameLevel, _parent);
                }
                GUILayout.EndHorizontal();
            }
        }
    }

    public BlockData GetBlock()
    {
        return _data.BlockDatas[_index].BlockData;
    }

}
