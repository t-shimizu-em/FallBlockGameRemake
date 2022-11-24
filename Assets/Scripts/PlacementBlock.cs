using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBlock : MonoBehaviour
{
    private float _wallInitPosX = -4.5f;
    private float _wallInitPosY = 8.5f;
    private int _wallWidth = 8;
    private int _wallHeight = 18;
    private float _nextBlockInitPosX = 13.0f;
    private float _nextBlockInitPosY = 0.5f;

    public GameObject GenerateNextFallBlock(GameObject[] _minos, int nextFallBlockNum)
    {
        return Instantiate(_minos[nextFallBlockNum], new Vector2(_nextBlockInitPosX, _nextBlockInitPosY), Quaternion.identity);
    }

    public void GenerateWallBlock(GameObject wallBlockPfb)
    {
        float currentPosX = _wallInitPosX;
        float currentPosY = _wallInitPosY;
        for (int i = 0; i < _wallHeight; i++)
        {
            Instantiate(wallBlockPfb, new Vector2(currentPosX, currentPosY - i), Quaternion.identity);
        }

        currentPosY -= _wallHeight - 1;
        currentPosX += 1;

        for (int i = 0; i < _wallWidth; i++)
        {
            Instantiate(wallBlockPfb, new Vector2(currentPosX + i, currentPosY), Quaternion.identity);
        }

        currentPosX += _wallWidth;

        for (int i = 0; i < _wallHeight; i++)
        {
            Instantiate(wallBlockPfb, new Vector2(currentPosX, currentPosY + i), Quaternion.identity);
        }
    }
}
