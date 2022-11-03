using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenRepository : MonoBehaviour
{
    [SerializeField] private CycleFramework _cycleFramework;
    [SerializeField] private UIScreen[] _screens;
    private Dictionary<CycleState, UIScreen> _cycleStateUIScreenPairs;
    public IReadOnlyDictionary<CycleState, UIScreen> CycleStateUIScreenPairs => _cycleStateUIScreenPairs;

    private void Awake()
    {
        UpdateScreen();
    }

    public void UpdateScreen()
    {
        foreach (UIScreen screen in _screens)
            screen.gameObject.SetActive(_cycleFramework.ActiveState == screen.State);

        _cycleStateUIScreenPairs = _screens.ToDictionary(screen => screen.State, screen => screen);
    }
}
