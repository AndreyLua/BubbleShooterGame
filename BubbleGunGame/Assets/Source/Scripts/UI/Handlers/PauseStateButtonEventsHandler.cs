using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PauseStateButtonEventsHandler : ScreenButtonEventsHandler
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
        _screen.SwitchStateButtons[0].SwitchToState += OnSwitchStateButtons;
       _screen.ResumeButton.ResumeButtonClicked += ResumeGame;
       _screen.RestartLvlButton.RestartLvl += RestartLvl;
    }

    private void RestartLvl()
    {
        _bubblesGenerator.ReloadLvl();
    }

    private void ResumeGame()
    {
        OnSwitchStateButtons(CycleState.Game);
    }

    private void OnSwitchStateButtons(CycleState state)
    {
        _cycleFramework.SetState(state);
    }

    public override void OnExit()
    {
        _screen.SwitchStateButtons[0].SwitchToState -= OnSwitchStateButtons;
        _screen.ResumeButton.ResumeButtonClicked -= ResumeGame;
        _screen.RestartLvlButton.RestartLvl -= RestartLvl;
    }
}
