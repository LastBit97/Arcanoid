using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorGrid
{
    private const float _leftPosition = -1.97f;
    private const float _upPosition = 3.415f;
    private const int _columnCount = 12;
    private const int _lineCount = 12;
    private const float _heightBlock = 0.365f;
    private const float _widthBlock = 0.365f;

    public Vector3 CheckPosition(Vector3 point)
    {
        float leftBorder = _leftPosition - _widthBlock / 2;
        float uupperBorder = _upPosition + _heightBlock / 2;
        float rightBorder = leftBorder + _widthBlock * _columnCount;
        float lowerBorder = uupperBorder - _heightBlock * _lineCount;
        float cellX = 0;
        float cellY = 0;

        // Если блок входит в игровое поле
        if (point.x > leftBorder && point.x < rightBorder &&
            point.y < uupperBorder && point.y > lowerBorder)
        {
            #region Возвращаем координаты центра ячейки сетки
            for (int i = 0; i < _columnCount; i++)
            {
                if (point.x > leftBorder && point.x < (leftBorder + _widthBlock))
                {
                    cellX = leftBorder + _widthBlock / 2;
                    break;
                }
                else
                {
                    leftBorder += _widthBlock;
                }
            }

            for (int i = 0; i < _lineCount; i++)
            {
                if (point.y < uupperBorder && point.y > (uupperBorder - _heightBlock))
                {
                    cellY = uupperBorder - _heightBlock / 2;
                    break;
                }
                else
                {
                    uupperBorder -= _heightBlock;
                }
            } 
            #endregion
        }
        else
        {
            Debug.LogWarning("out of play zone");
        }

        return new Vector3(cellX, cellY);
    }
}
