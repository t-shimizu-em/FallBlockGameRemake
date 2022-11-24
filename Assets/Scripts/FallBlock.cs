using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    private float _initPosX = -0.5f;
    private float _initPosY = 8.5f;

    public GameObject GenerateFallBlock(GameObject[] _minos, int fallBlockNum)
    {
        return Instantiate(_minos[fallBlockNum], new Vector2(_initPosX, _initPosY), Quaternion.identity);
    }
}
