using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartLvlButton : MonoBehaviour
{
    private Button _restartLvlButton;

    public event Action RestartLvl;

    private void Awake()
    {
        _restartLvlButton = gameObject.GetComponent<Button>();
        _restartLvlButton.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        RestartLvl?.Invoke();
    }
}
