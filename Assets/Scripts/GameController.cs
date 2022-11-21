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
    }

    void Update()
    {
        
    }

    private void GenerateField()
    {

    }
}
