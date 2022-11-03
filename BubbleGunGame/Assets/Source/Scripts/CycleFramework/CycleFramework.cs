using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CycleFramework : MonoBehaviour
{
    [SerializeField] private CycleState _activeState;
    private CycleFrameworkStateMachine _stateMachine;

    public CycleState ActiveState => _activeState;
    public IReadOnlyList<CycleFrameworkState> States;

    private void Awake()
    {
        States = GetComponentsInChildren<CycleFrameworkState>(true);
        _stateMachine = new CycleFrameworkStateMachine(States.ToDictionary(state => state.State, state => state));
        foreach (CycleFrameworkState state in States)
            _stateMachine.Init(state.State);
        _stateMachine.SetStartState(_activeState);
    }
    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    public void SetState(CycleState state)
    {
        _activeState = state;
        _stateMachine.SetState(state);
    }
}
