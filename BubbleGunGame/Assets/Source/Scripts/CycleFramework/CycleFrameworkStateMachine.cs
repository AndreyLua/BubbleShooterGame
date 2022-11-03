using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleFrameworkStateMachine
{
    private CycleFrameworkState _activeState;
    private IReadOnlyDictionary<CycleState,CycleFrameworkState> _states;

    public CycleFrameworkState ActiveState => _activeState;

    public CycleFrameworkStateMachine(IReadOnlyDictionary<CycleState,CycleFrameworkState> states)
    {
        _states = states;
    }

    public void Init(CycleState state)
    {
        _states[state].OnInit();
    }

    public void SetStartState(CycleState state)
    {
        _activeState = _states[state];
        _activeState.OnEnter();
    }

    public void SetState(CycleState state)
    {
        _activeState.OnExit();
        _activeState = _states[state];
        _activeState.OnEnter();
    }

    public void Update()
    {
        _activeState.OnUpdate();
    }
    public void FixedUpdate()
    {
        _activeState.OnFixedUpdate();
    }
}
