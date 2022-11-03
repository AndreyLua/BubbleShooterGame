using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuStateButtonEventsHandler : ScreenButtonEventsHandler
{
    [SerializeField] private BubblesGenerator _bubblesGenerator;

    [Inject]
    private CycleFramework _cycleFramework;
    [Inject]
    private ScreenRepository _screenRepository;

    private UIScreen _screen;

    public override void OnEnter()
    {
        _screenRepository.UpdateScreen();
        _screen = _screenRepository.CycleStateUIScreenPairs[_cycleFramework.ActiveState];
        _screen.LevelButtons[0].LevelButtonCliked += OnLevelButtonCliked;
    }

    private void OnLevelButtonCliked(int numberLvl)
    {
        _bubblesGenerator.ReloadLvl();
        _cycleFramework.SetState(CycleState.Game);
    }

    public override void OnExit()
    {
        _screen.LevelButtons[0].LevelButtonCliked -= OnLevelButtonCliked;
    }
}
