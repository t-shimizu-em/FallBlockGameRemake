using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _wallBlockPfb;
    [SerializeField] private GameObject _fallBlockPfb;
    [SerializeField] private GameObject[] _minos;

    private PlacementBlock placementBlock = new PlacementBlock();
    private FallBlock fallBlock = new FallBlock();
    private GameStatus gameStatus = new GameStatus();
    private bool _isPause;

    void Start()
    {
        _pauseButton.onClick.AddListener(() =>
        {
            _isPause = true;
            if (_isPause)
            {
                _pausePanel.SetActive(true);
            }
            else
            {
                _pausePanel.SetActive(false);
            }
        });

        _backButton.onClick.AddListener(() =>
        {
            LoadManager.Instance.LoadScene("Title");
        });

        //_retryButton.onClick.AddListener();

        // 壁ブロック生成
        placementBlock.GenerateWallBlock(_wallBlockPfb);

        // 初期処理
        gameStatus.Init();

        // 落下ブロック生成
        fallBlock.GenerateFallBlock(_minos, gameStatus._fallBlockNum);

        //次落下ブロック生成
        placementBlock.GenerateNextFallBlock(_minos, gameStatus._nextFallBlockNum);
    }

    void Update()
    {
        
    }
}
