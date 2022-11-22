using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [HideInInspector] public int _fallBlockNum;
    [HideInInspector] public int _nextFallBlockNum;
    [HideInInspector] public int _gameStatus;

    private const int GameOver = 0;
    private const int Start = 1;
    private const int Ground = 2;
    private const int Erase = 3;

    public void Init()
    {
        _fallBlockNum = Random.Range(0, 7);
        _nextFallBlockNum = Random.Range(0, 7);
    }

    public void StartProcess()
    {
        _fallBlockNum = _nextFallBlockNum;
        _nextFallBlockNum = Random.Range(0, 7);


    }

    public void GroundProcess()
    {

    }
}
