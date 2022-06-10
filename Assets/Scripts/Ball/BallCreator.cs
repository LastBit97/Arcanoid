using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private const float OffsetY = 0.25f;
    private readonly List<GameObject> _saveBalls = new List<GameObject>();
    public void Create()
    {
        _saveBalls.Clear();
        _saveBalls.Add(Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + OffsetY), Quaternion.identity, transform));
    }

    public void CreateClone()
    {
        foreach (var item in _saveBalls)
        {
            if (item != null)
            {
                GameObject cloneOne = Instantiate(ballPrefab, new Vector3(item.transform.position.x, item.transform.position.y),
                    Quaternion.identity, null);

                GameObject cloneTwo = Instantiate(ballPrefab, new Vector3(item.transform.position.x, item.transform.position.y),
                    Quaternion.identity, null);
                cloneOne.GetComponent<BallMove>().StartClone(0.5f);
                cloneTwo.GetComponent<BallMove>().StartClone(-0.5f);
                _saveBalls.Add(cloneOne);
                _saveBalls.Add(cloneTwo);
                break;
            }
        }
    }

}
