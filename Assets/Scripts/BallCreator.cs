using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private const float OffsetY = 0.25f;
    void Start()
    {
        Create();
    }

    private void Create()
    {
        Instantiate(ballPrefab, new Vector2(transform.position.x, transform.position.y + OffsetY), Quaternion.identity, transform);
    }

}
