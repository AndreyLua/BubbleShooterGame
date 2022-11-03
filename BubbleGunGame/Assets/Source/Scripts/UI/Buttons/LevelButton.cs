using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int numberLevel;
    private Button _levelButton;
    public event Action<int> LevelButtonCliked;

    private void Awake()
    {
        _levelButton = gameObject.GetComponent<Button>();
        _levelButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    { 
        LevelButtonCliked?.Invoke(numberLevel);
    }
}

