using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Button _tapArea;

    private bool isClicked;

    void Start()
    {
        if (!isClicked)
        {
            isClicked = true;
            _tapArea.onClick.AddListener(() => LoadManager.Instance.FirstLoadScene("Game"));
        }
    }
}
