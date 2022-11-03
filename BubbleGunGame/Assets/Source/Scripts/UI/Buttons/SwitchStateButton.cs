using System;
using UnityEngine;
using UnityEngine.UI;

public class SwitchStateButton: MonoBehaviour
{
    [SerializeField] private CycleState _state;

    private Button _switchButton;
    public event Action<CycleState> SwitchToState;

    private void Awake()
    {
        _switchButton = gameObject.GetComponent<Button>();
        _switchButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    { 
        SwitchToState?.Invoke(_state);
    }
}
