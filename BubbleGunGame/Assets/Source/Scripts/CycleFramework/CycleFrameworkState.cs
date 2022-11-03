using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleFrameworkState : MonoBehaviour
{
    [SerializeField] private CycleState _id;
    [SerializeField] private ScreenButtonEventsHandler _screenButtonEventsHandler;
    private IReadOnlyList<CycleInitializerBase> _cycleInitializerBases;

    public CycleState State => _id;
  
    public void OnEnter()
    {
        _screenButtonEventsHandler.OnEnter();
    }
    public void OnExit()
    {
        _screenButtonEventsHandler.OnExit();
    }

    public void OnInit()
    {
        _cycleInitializerBases = GetComponentsInChildren<CycleInitializerBase>(true);
        foreach (CycleInitializerBase cycleInitializer in _cycleInitializerBases)
        {
            cycleInitializer.OnInit();
        }
    }

    public void OnUpdate()
    {
        foreach (CycleInitializerBase cycleInitializer in _cycleInitializerBases)
        {
            cycleInitializer.OnUpdate();
        }
    }

    public void OnFixedUpdate()
    {
        foreach (CycleInitializerBase cycleInitializer in _cycleInitializerBases)
        {
            cycleInitializer.OnFixedUpdate();
        }
    }
}
